//<summary>
//  Title   : Extrernal Data Source Consument Component
//  System  : Microsoft Visual C# .NET 2012
//  $LastChangedDate:$
//  $Rev:$
//  $LastChangedBy:$
//  $URL:$
//  $Id:$
//
//  Copyright (C) 2013, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace CAS.UA.Server.DataSource.External
{
  /// <summary>
  /// Extrernal Data Source Consument Component
  /// </summary>
  public partial class ExtrernalDataSourceComponent: Component
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ExtrernalDataSourceComponent"/> class.
    /// </summary>
    public ExtrernalDataSourceComponent()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtrernalDataSourceComponent"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public ExtrernalDataSourceComponent( IContainer container )
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
