//<summary>
//  Title   : MonitoredItemQueue
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Collections.Generic;
using Opc.Ua;

namespace CAS.UA.Server.Library.Base
{
  /// <summary>
  /// Provides a queue for data changes.
  /// </summary>
  public class MonitoredItemQueue
  {
    #region creators
    /// <summary>
    /// Creates an empty queue.
    /// </summary>
    public MonitoredItemQueue()
    {
      m_values = null;
      m_errors = null;
      m_start = -1;
      m_end = -1;
      m_overflow = -1;
      m_discardOldest = false;
      m_nextSampleTime = 0;
      m_samplingInterval = 0;
    }
    #endregion

        #region Public Methods
    /// <summary>
    /// Gets the current queue size.
    /// </summary>
    public uint QueueSize
    {
      get
      {
        if ( m_values == null )
        {
          return 0;
        }

        return (uint)m_values.Length;
      }
    }
    /// <summary>
    /// Sets the sampling interval used when queuing values.
    /// </summary>
    /// <param name="samplingInterval">The new sampling interval.</param>
    public void SetSamplingInterval( double samplingInterval )
    {
      // substract the previous sampling interval.
      if ( m_samplingInterval < m_nextSampleTime )
      {
        m_nextSampleTime -= m_samplingInterval;
      }

      // calculate the next sampling interval.
      m_samplingInterval = (long)( samplingInterval * TimeSpan.TicksPerMillisecond );

      if ( m_samplingInterval > 0 )
      {
        m_nextSampleTime += m_samplingInterval;
      }
      else
      {
        m_nextSampleTime = 0;
      }
    }
    /// <summary>
    /// Sets the queue size.
    /// </summary>
    /// <param name="queueSize">The new queue size.</param>
    /// <param name="discardOldest">Whether to discard the oldest values if the queue overflows.</param>
    /// <param name="diagnosticsMasks">Specifies which diagnostics which should be kept in the queue.</param>
    public void SetQueueSize( uint queueSize, bool discardOldest, DiagnosticsMasks diagnosticsMasks )
    {
      int length = (int)queueSize;

      if ( length < 1 )
      {
        length = 1;
      }

      int start = m_start;
      int end = m_end;

      // create new queue.
      DataValue[] values = new DataValue[ length ];
      ServiceResult[] errors = null;

      if ( ( diagnosticsMasks & DiagnosticsMasks.OperationAll ) != 0 )
      {
        errors = new ServiceResult[ length ];
      }

      // copy existing values.
      List<DataValue> existingValues = null;
      List<ServiceResult> existingErrors = null;

      if ( m_start >= 0 )
      {
        existingValues = new List<DataValue>();
        existingErrors = new List<ServiceResult>();

        DataValue value = null;
        ServiceResult error = null;

        while ( Dequeue( out value, out error ) )
        {
          existingValues.Add( value );
          existingErrors.Add( error );
        }
      }

      // update internals.
      m_values = values;
      m_errors = errors;
      m_start = -1;
      m_end = 0;
      m_overflow = -1;
      m_discardOldest = discardOldest;

      // requeue the data.
      if ( existingValues != null )
      {
        for ( int ii = 0; ii < existingValues.Count; ii++ )
        {
          Enqueue( existingValues[ ii ], existingErrors[ ii ] );
        }
      }
    }
    /// <summary>
    /// Adds the value to the queue.
    /// </summary>
    /// <param name="value">The value to queue.</param>
    /// <param name="error">The error to queue.</param>
    public void QueueValue( DataValue value, ServiceResult error )
    {
      long now = DateTime.UtcNow.Ticks;

      if ( m_start >= 0 )
      {
        // check if too soon for another sample.
        if ( now < m_nextSampleTime )
        {
          int last = m_end - 1;

          if ( last < 0 )
          {
            last = m_values.Length - 1;
          }

          // replace last value and error.
          m_values[ last ] = value;

          if ( m_errors != null )
          {
            m_errors[ last ] = error;
          }

          return;
        }
      }

      // update next sample time.
      if ( m_nextSampleTime > 0 )
      {
        long delta = now - m_nextSampleTime;

        if ( m_samplingInterval > 0 && delta >= 0 )
        {
          m_nextSampleTime += ( ( delta / m_samplingInterval ) + 1 ) * m_samplingInterval;
        }
      }
      else
      {
        m_nextSampleTime = now + m_samplingInterval;
      }

      // queue next value.
      Enqueue( value, error );
    }
    /// <summary>
    /// Publishes the oldest value in the queue.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="error">The error associated with the value.</param>
    /// <returns>True if a value was found. False if the queue is empty.</returns>
    public bool Publish( out DataValue value, out ServiceResult error )
    {
      return Dequeue( out value, out error );
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Adds the value to the queue. Discards values if the queue is full.
    /// </summary>
    /// <param name="value">The value to add.</param>
    /// <param name="error">The error to add.</param>
    private void Enqueue( DataValue value, ServiceResult error )
    {
      // check for empty queue.
      if ( m_start < 0 )
      {
        m_start = 0;
        m_end = 1;
        m_overflow = -1;

        m_values[ m_start ] = value;

        if ( m_errors != null )
        {
          m_errors[ m_start ] = error;
        }

        return;
      }

      int next = m_end;

      // check for wrap around.
      if ( next >= m_values.Length )
      {
        next = 0;
      }

      // check if queue is full.
      if ( m_start == next )
      {
        if ( !m_discardOldest )
        {
          m_overflow = m_end - 1;
          return;
        }

        // remove oldest value.
        m_start++;

        if ( m_start >= m_values.Length )
        {
          m_start = 0;
        }

        // set overflow bit.
        m_overflow = m_start;
      }

      // add value.
      m_values[ next ] = value;

      if ( m_errors != null )
      {
        m_errors[ next ] = error;
      }

      m_end = next + 1;
    }
    /// <summary>
    /// Removes a value and an error from the queue.
    /// </summary>
    /// <param name="value">The value removed from the queue.</param>
    /// <param name="error">The error removed from the queue.</param>
    /// <returns>True if a value was found. False if the queue is empty.</returns>
    private bool Dequeue( out DataValue value, out ServiceResult error )
    {
      value = null;
      error = null;

      // check for empty queue.
      if ( m_start < 0 )
      {
        return false;
      }

      value = m_values[ m_start ];
      m_values[ m_start ] = null;

      if ( m_errors != null )
      {
        error = m_errors[ m_start ];
        m_errors[ m_start ] = null;
      }

      // set the overflow bit.
      if ( m_overflow == m_start )
      {
        SetOverflowBit( ref value, ref error );
        m_overflow = -1;
      }

      m_start++;

      // check if queue has been emptied.
      if ( m_start == m_end )
      {
        m_start = -1;
        m_end = 0;
      }

      // check for wrap around.
      else if ( m_start >= m_values.Length )
      {
        m_start = 0;
      }

      return true;
    }
    /// <summary>
    /// Sets the overflow bit in the value and error.
    /// </summary>
    /// <param name="value">The value to update.</param>
    /// <param name="error">The error to update.</param>
    private void SetOverflowBit( ref DataValue value, ref ServiceResult error )
    {
      if ( value != null )
      {
        StatusCode status = value.StatusCode;
        status.Overflow = true;
        value.StatusCode = status;
      }

      if ( error != null )
      {
        StatusCode status = error.StatusCode;
        status.Overflow = true;

        // have to copy before updating because the ServiceResult is invariant.
        ServiceResult copy = new ServiceResult(
            status,
            error.SymbolicId,
            error.NamespaceUri,
            error.LocalizedText,
            error.AdditionalInfo,
            error.InnerResult );

        error = copy;
      }
    }
        #endregion
        #region Private Fields
    private DataValue[] m_values;
    private ServiceResult[] m_errors;
    private int m_start;
    private int m_end;
    private int m_overflow;
    private bool m_discardOldest;
    private long m_nextSampleTime;
    private long m_samplingInterval;
    #endregion
  }
}
