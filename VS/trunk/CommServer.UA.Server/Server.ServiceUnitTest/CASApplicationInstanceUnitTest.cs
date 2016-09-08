using CAS.UA.Server.ServerConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opc.Ua;
using System;
using System.Diagnostics;
using System.IO;

namespace CAS.CommServer.UA.Server.Service.UnitTest
{

  [TestClass]
  [DeploymentItem(@"EmbeddedExample\DemoConfiguration\", @"EmbeddedExample\DemoConfiguration\")]
  public class CASApplicationInstanceUnitTest
  {
    [TestMethod]
    public void CreatorTestTest()
    {
      CASApplicationInstance _instance = new CASApplicationInstance();
      Assert.IsNull(_instance.ApplicationConfiguration);
      Assert.AreSame(typeof(CASConfiguration), _instance.ApplicationConfigurationType);
      Assert.AreEqual<string>(null, _instance.ApplicationName);
      Assert.AreEqual<ApplicationType>(ApplicationType.Server, _instance.ApplicationType);
      Assert.AreEqual<string>("CAS.UA.Server", _instance.ConfigSectionName);
      Assert.IsNull(_instance.InstallConfig);
      Assert.IsNull(_instance.Server);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void StartNullServerTest()
    {
      CASApplicationInstance _instance = new CASApplicationInstance();
      _instance.Start(null);
    }
    [TestMethod]
    public void LoadApplicationConfigurationTest()
    {
      Debug.WriteLine(Environment.CurrentDirectory);
      FileInfo file = new FileInfo(Utils.Format("{0}\\{1}", Environment.CurrentDirectory, @"EmbeddedExample\DemoConfiguration\BoilerExample.uasconfig"));
      Assert.IsTrue(file.Exists, $"Wrong deployment file doesn't exist {file.FullName}");
      using (Main _main = new Main())
      {
        CASApplicationInstance _instance = new CASApplicationInstance();
        _instance.LoadApplicationConfiguration(true);
        Assert.IsNotNull(_instance.ApplicationConfiguration);
        Assert.IsInstanceOfType(_instance.ApplicationConfiguration, typeof(CASConfiguration));
        Assert.AreSame(typeof(CASConfiguration), _instance.ApplicationConfigurationType);
        Assert.AreEqual<string>(null, _instance.ApplicationName);
        Assert.AreEqual<ApplicationType>(ApplicationType.Server, _instance.ApplicationType);
        Assert.AreEqual<string>("CAS.UA.Server", _instance.ConfigSectionName);
        Assert.IsNull(_instance.InstallConfig);
        Assert.IsNull(_instance.Server);
      }
    }
  }
}

