using projetImage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using NSubstitute;

namespace Tests_functionsFile
{
    
    
    /// <summary>
    ///This is a test class for FunctionsFileTest and is intended
    ///to contain all FunctionsFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FunctionsFileTest
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
        ///A test for LoadImageFromFile. Check if picture is loaded from a folder and inserted in pictureBox.
        ///</summary>
        [TestMethod()]
        public void LoadImageFromFileTestImgLoadedOk()
        {
            Form1 form1 = new Form1();
            FunctionsFile fFile = new FunctionsFile(form1);
            // load a picture in pictureBox
            string path = Environment.CurrentDirectory.ToString();
            int pos = path.IndexOf("TestResults");
            path = path.Substring(0, pos);
            path += "Tests_functionsFile\\pictures\\img507x433.png";//projetImage\Tests_functionsFile\pictures\img507x433.png
            //Console.WriteLine("***********" + path + "-*******");
            form1.getPictureBox().Load(path);
            // check picture loaded
            int imgHeight =form1.getPictureBox().Image.Height;
            int imgWidth = form1.getPictureBox().Image.Width;
            Assert.AreEqual(433, imgHeight);
            Assert.AreEqual(507, imgWidth);
            
        }
        /// <summary>
        ///A test for LoadImageFromFile. Check if picture is loaded from a folder and inserted in pictureBox.
        ///</summary>
        [TestMethod()]
        public void LoadImageFromFileTestFailCatch()
        {
            var msg = "init";
            var fFile = Substitute.For<I_FunctionsFile>();
            // I test catch part
            fFile
                    .When(x => x.LoadImageFromFile())
                    .Do(x => { throw new Exception("Simule a fail"); });
            try 
            {
                fFile.LoadImageFromFile();
                 msg = "try";
            }
            catch(Exception e)
            {
                msg = "catch";
            }
            Assert.AreEqual("catch", msg);
        }
        /// <summary>
        ///A test for LoadImageFromFile. Check if picture is loaded from a folder and inserted in pictureBox.
        ///</summary>
        [TestMethod()]
        public void LoadImageFromFileTestPassTry()
        {
            var msg = "init";
            var fFile = Substitute.For<I_FunctionsFile>();

            // I test catch part
            fFile
                    .When(x => x.LoadImageFromFile())
                    .Do(x => {  });

            try
            {
                fFile.LoadImageFromFile();
                msg = "try";
            }
            catch (Exception e)
            {
                msg = "catch";
            }
            Assert.AreEqual("try", msg);
        }

        /*
         * /// <summary>
        ///A test for LoadImageFromDb
        ///</summary>
        [TestMethod()]
        public void LoadImageFromDbTest()
        {
            Form1 form1 = null; // TODO: Initialize to an appropriate value
            FunctionsFile target = new FunctionsFile(form1); // TODO: Initialize to an appropriate value
            Image img = null; // TODO: Initialize to an appropriate value
            target.LoadImageFromDb(img);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
       /// <summary>
       ///A test for SaveImage
       ///</summary>
       [TestMethod()]
       public void SaveImageTest()
       {
           Form1 form1 = null; // TODO: Initialize to an appropriate value
           FunctionsFile target = new FunctionsFile(form1); // TODO: Initialize to an appropriate value
           target.SaveImage();
           Assert.Inconclusive("A method that does not return a value cannot be verified.");
       }

       /// <summary>
       ///A test for FunctionsFile Constructor
       ///</summary>
       [TestMethod()]
       public void FunctionsFileConstructorTest()
       {
           Form1 form1 = null; // TODO: Initialize to an appropriate value
           FunctionsFile target = new FunctionsFile(form1);
           Assert.Inconclusive("TODO: Implement code to verify target");
       }

       /// <summary>
       ///A test for CheckName
       ///</summary>
       [TestMethod()]
       public void CheckNameTest()
       {
           Form1 form1 = null; // TODO: Initialize to an appropriate value
           FunctionsFile target = new FunctionsFile(form1); // TODO: Initialize to an appropriate value
           string name = string.Empty; // TODO: Initialize to an appropriate value
           string expected = string.Empty; // TODO: Initialize to an appropriate value
           string actual;
           actual = target.CheckName(name);
           Assert.AreEqual(expected, actual);
           Assert.Inconclusive("Verify the correctness of this test method.");
       }
       */
    }
}
