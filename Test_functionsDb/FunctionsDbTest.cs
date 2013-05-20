using projetImage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NSubstitute;
using System.Data.SqlClient;

namespace Test_functionsDb
{
    
    
    /// <summary>
    ///This is a test class for FunctionsDbTest and is intended
    ///to contain all FunctionsDbTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FunctionsDbTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SaveImageInDb
        ///</summary>
        [TestMethod()]
        public void SaveImageInDbTestFail_Catch()
        {
            var msg = "init";
            var fDb = Substitute.For<I_FunctionsDb>();
            // I test catch part
            fDb
                    .When(x => x.SaveImageInDb())
                    .Do(x => { throw new Exception("Simule a fail"); });
            try
            {
                fDb.SaveImageInDb();
                msg = "try";
            }
            catch (Exception e)
            {
                msg = "catch";
            }
            Assert.AreEqual("catch", msg);
        }
        /// <summary>
        ///A test for SaveImageInDb
        ///</summary>
        [TestMethod()]
        public void SaveImageInDbTestSuccess_Try()
        {
            var msg = "init";
            var fDb = Substitute.For<I_FunctionsDb>();
            // I test try part
            fDb
                    .When(x => x.SaveImageInDb())
                    .Do(x => {  });
            try
            {
                fDb.SaveImageInDb();
                msg = "try";
            }
            catch (Exception e)
            {
                msg = "catch";
            }
            Assert.AreEqual("try", msg);
        }

        /// <summary>
        ///A test for loadImageFromDb
        ///</summary>
        [TestMethod()]
        public void loadImageFromDbTestFail_catch()
        {
            var msg = "init";
            var fDb = Substitute.For<I_FunctionsDb>();
            // I test catch part
            fDb
                    .When(x => x.loadImageFromDb("fail"))
                    .Do(x => { throw new Exception("Simule a fail"); });
            try
            {
                fDb.loadImageFromDb("fail");
                msg = "try";
            }
            catch (Exception e)
            {
                msg = "catch";
            }
            Assert.AreEqual("catch", msg);
        }
        /// <summary>
        ///A test for loadImageFromDb
        ///</summary>
        [TestMethod()]
        public void loadImageFromDbTestSuccess_try()
        {
            var msg = "init";
            var fDb = Substitute.For<I_FunctionsDb>();
            // I test catch part
            fDb
                    .When(x => x.loadImageFromDb("yououou"))
                    .Do(x => {  });
            try
            {
                fDb.loadImageFromDb("yououou");
                msg = "try";
            }
            catch (Exception e)
            {
                msg = "catch";
            }
            Assert.AreEqual("try", msg);
        }

        /// <summary>
        ///A test for checkName
        ///</summary>
        [TestMethod()]
        public void checkNameTest_bothPossibility()
        {
            var fDb = Substitute.For<I_FunctionsDb>();
            // if name --> same name
            fDb.checkName("toto").Returns("toto");
            Assert.AreEqual("toto", fDb.checkName("toto"));
            // if noName --> no_name
            fDb.checkName("").Returns("no_name");
            Assert.AreEqual(fDb.checkName("no_name"),"");
        }
    }
}
