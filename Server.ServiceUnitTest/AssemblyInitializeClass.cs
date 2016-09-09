
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CAS.CommServer.UA.Server.Service.UnitTest
{
  [TestClass]
  public class AssemblyInitializeClass
  {
    private static TestContext m_TestContext;
    internal const string FileName = @"EmbeddedExample\DemoConfiguration\BoilerExample.uasconfig";
    internal static FileInfo CASConfigurationFileInfo { get { return new FileInfo(FileName); } }

    [AssemblyInitialize()]
    [DeploymentItem(@"EmbeddedExample\DemoConfiguration\", @"EmbeddedExample\DemoConfiguration\")]
    public static void AssemblyInitializeMethod(TestContext context)
    {
      m_TestContext = context;
    }
    [AssemblyCleanup]
    public static void AssemblyCleanupMethod() { }
    [TestMethod]
    public void DeploymentTest()
    {
      Assert.IsTrue(CASConfigurationFileInfo.Exists);
      Assert.IsNotNull(m_TestContext);
    }
  }
}
