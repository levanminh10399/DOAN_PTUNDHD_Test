using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using NUnit.Framework;

namespace BackEndUnitTest.Test
{
    [TestFixture]
    public class XeTest
    {
        private XeRepository xeRepository;

        [SetUp]
        public void SetUp()
        {
            xeRepository = new XeRepository();
        }

        [Test]
        public void findByUserId()
        {
            List<Xe> xes = xeRepository.findByUserId(1);
            Xe xe = xes[0];

            Assert.AreEqual(1, xes.Count());

            Assert.AreEqual("123123", xe.SoKhung);
            Assert.AreEqual("221ADW", xe.SoMay);
            Assert.AreEqual(40000000, xe.GiaTien);
            //Assert.AreEqual(1, xe.LoaiXe_id);
            //Assert.AreEqual(1, xe.NguoiDung_id);
            Assert.AreEqual("81B1-32135", xe.BienSo);

        }
    }
}
