//_______________________________________________________________
//  Title   : External Data Source Consumed Component
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.ComponentModel;

namespace CAS.UA.Server.DataSource.External
{

  /// <summary>
  /// External Data Source Consumed Component
  /// </summary>
  public partial class ExternalDataSourceComponent: Component
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ExternalDataSourceComponent" /> class.
    /// </summary>
    public ExternalDataSourceComponent()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ExternalDataSourceComponent" /> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public ExternalDataSourceComponent( IContainer container )
    {
      container.Add( this );
      InitializeComponent();
    }
    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public void Initialize()
    {
      //TODO TBD;
    }

  }
}
