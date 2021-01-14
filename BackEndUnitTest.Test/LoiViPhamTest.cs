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
    public class LoiViPhamTest
    {
        private LoiViPhamRepository loiViPhamRepository;

        [SetUp]
        public void SetUp()
        {
            loiViPhamRepository = new LoiViPhamRepository();
        }

        [Test]
        public void findAll()
        {
            List<LoiViPham> loiViPhams = loiViPhamRepository.findAll();
            LoiViPham loiViPham_01 = loiViPhams.First();
            LoiViPham loiViPham_02 = loiViPhams.Last();

            Assert.AreEqual(14, loiViPhams.Count());

            Assert.AreEqual("Vượt đèn đỏ", loiViPham_01.LoiViPham1);
            Assert.AreEqual(1000000, loiViPham_01.MucPhat);
            Assert.AreEqual(20, loiViPham_01.DiemTru);

            Assert.AreEqual("Không có  giấy phép lái xe", loiViPham_02.LoiViPham1);
            Assert.AreEqual(800000, loiViPham_02.MucPhat);
            Assert.AreEqual(-2, loiViPham_02.DiemTru);
        }
    }
}
