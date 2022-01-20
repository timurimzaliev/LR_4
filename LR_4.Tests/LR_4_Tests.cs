using NUnit.Framework;

namespace LR_4.Tests
{
    public class LR_4_Tests
    {
        [Test]
        public void Add_10and20_30return()
        {
            Myint myint = new Myint();

            string a = "10";
            string b = "20";
            string expected = "30";

            string actual = myint.Add(a, b, false);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_18446744073709551615and254438773709551615695_272885517783261167310return()
        {
            Myint myint = new Myint();

            string a = "18446744073709551615";
            string b = "254438773709551615695";
            string expected = "272885517783261167310";

            string actual = myint.Add(a, b, false);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Subtract_6789and1235_5554return()
        {
            Myint myint = new Myint();

            string a = "6789";
            string b = "1235";
            string expected = "5554";

            string actual = myint.Subtract(a, b, false);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Subtract_272885517783261167310and254438773709551615695_18446744073709551615return()
        {
            Myint myint = new Myint();

            string a = "272885517783261167310";
            string b = "254438773709551615695";
            string expected = "18446744073709551615";

            string actual = myint.Subtract(a, b, false);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_3895and12567_48948465return()
        {
            Myint myint = new Myint();

            string a = "3895";
            string b = "12567";
            string expected = "48948465";

            string actual = myint.Multiply(a, b, false);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Divide_12567and38_3ostreturn()
        {
            Myint myint = new Myint();

            string a = "12567";
            string b = "3895";
            string expected = "3,";

            string actual = myint.Divide(a, b, false);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Divide_mines125475andmines25_5019return()
        {
            Myint myint = new Myint();

            string a = "-125475";
            string b = "-25";
            string expected = "5019";

            string actual = myint.Divide(a, b, false);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Divide_mines12567and3895_3ostreturn()
        {
            Myint myint = new Myint();

            string a = "-12567";
            string b = "38";
            string expected = "-330,";

            string actual = myint.Divide(a, b, false);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Gcd_96and56_8return()
        {
            Myint myint = new Myint();

            string a = "96";
            string b = "56";
            string expected = "8";

            string actual = myint.Gcd(a, b);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Gcd_595369043and13413204_3131return()
        {
            Myint myint = new Myint();

            string a = "595369043";
            string b = "13413204";
            string expected = "3131";

            string actual = myint.Gcd(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}