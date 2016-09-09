using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CAS.UA.Server.DataBindings
{
  /// <summary>
  /// Hanles nodes identifiers
  /// </summary>
  internal class NodesIdentifiersCollection : SortedDictionary<uint, string>
  {

    #region creators
    public NodesIdentifiersCollection() { }
    #endregion

    #region public
    /// <summary>
    /// Loads the identifiers of the model nodes from a CSV file.
    /// </summary>
    /// <param name="identifierFile">The file containing the list of identifiers.</param>
    public void LoadIdentifiersFromStream(FileInfo identifierFile)
    {
      string _mn = "LoadIdentifiersFromStream";
      try
      {
        using (StreamReader reader = identifierFile.OpenText())
        {
          while (!reader.EndOfStream)
          {
            string line = reader.ReadLine();
            if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
              continue;
            int index = line.IndexOf(',');
            if (index == -1)
              continue;
            // remove the node class if it is present.
            int lastIndex = line.LastIndexOf(',');
            if (lastIndex != -1 && index != lastIndex)
              line = line.Substring(0, lastIndex);
            try
            {
              string name = line.Substring(0, index).Trim();
              string id = line.Substring(index + 1).Trim();
              if (!id.StartsWith("\""))
              {
                uint numericId = Convert.ToUInt32(id);
                if (this.ContainsKey(numericId))
                {
                  string duplicatedNumericId = string.Format(Properties.Resources.AssertWhenTheNumericIdIsDuplicated, identifierFile.Name, name, numericId);
                  TraceEvent.Tracer.TraceWarning(50, this.GetType().Name + _mn, duplicatedNumericId);
                  continue;
                }
                this[numericId] = name;
              }
            }
            catch (Exception ex)
            {
              String _msg = String.Format(Properties.Resources.WrongFileFormatTemplate, identifierFile.Name, line, ex.Message);
              TraceEvent.Tracer.TraceError(61, this.GetType().Name + _mn, _msg);
              continue;
            }
          }
        }
      }
      catch (Exception ex)
      {
        String _msg = String.Format(Properties.Resources.CSVFileLoadingError, identifierFile.Name, ex.Message);
        TraceEvent.Tracer.TraceError(61, this.GetType().Name + _mn, _msg);
      }
    }
    #endregion

  }
}
