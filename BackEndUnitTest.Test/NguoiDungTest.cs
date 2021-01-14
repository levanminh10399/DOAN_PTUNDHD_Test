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
    public class NguoiDungTest
    {
        private NguoiDungRepository nguoiDungRepository;
        [SetUp]
        public void SetUp()
        {
            nguoiDungRepository = new NguoiDungRepository();
        }
        [Test]
        public void  findByCMND()
        {
            //kiểm tra 1 CMND hợp lệ
            NguoiDung nguoiDung = nguoiDungRepository.findByCMND("231144199");
            DateTime ngaySinh = new DateTime(nguoiDung.NgaySinh.Value.Year, nguoiDung.NgaySinh.Value.Month, nguoiDung.NgaySinh.Value.Day);
            Assert.AreEqual("test3", nguoiDung.Ten);
            Assert.AreEqual("Nam", nguoiDung.GioiTinh);
            Assert.AreEqual("TP HCM", nguoiDung.DiaChi);
            Assert.AreEqual(new DateTime(1999, 10, 3), ngaySinh);

            ///Kiểm tra CMND chưa tồn tại
            Assert.AreEqual(null, nguoiDungRepository.findByCMND("1232112312"));

            
        }
        
        [Test]
        public void findByID()
        {
            //kiểm tra 1 id hợp lệ
            NguoiDung nguoiDung = nguoiDungRepository.findById(2);
            DateTime ngaySinh = new DateTime(nguoiDung.NgaySinh.Value.Year,nguoiDung.NgaySinh.Value.Month,nguoiDung.NgaySinh.Value.Day);
            Assert.AreEqual("test2", nguoiDung.Ten);
            Assert.AreEqual("231144159", nguoiDung.CMND);
            Assert.AreEqual(new DateTime(2021,1,8), ngaySinh);

            //Kiểm tra 1 Id chưa tồn tại
            Assert.AreEqual(null, nguoiDungRepository.findById(10));
        }
        //[Test]
        //public void addNguoiDung()
        //{
        //    NguoiDung nguoiDung = new NguoiDung() { Ten = "Lê Văn Minh", CMND = "231144254", GioiTinh = "Nam", NgaySinh = new DateTime(1999, 3, 10), DiaChi = "Gia Lai", username = "vanminh", password = "123" };
        //    Assert.AreEqual(true, nguoiDungRepository.addNguoiDung(nguoiDung));
        //}
        [Test]
        public void nguoiDungAuth()
        {
            //Kiểm tra 1 username và password hợp lệ
            Assert.AreEqual(1, nguoiDungRepository.auth("test1", "123").ID);
            //Kiểm tra 1 username không hợp lệ
            Assert.AreEqual(null, nguoiDungRepository.auth("test100", "123"));
            //Kiểm tra 1 password không hợp lệ
            Assert.AreEqual(null, nguoiDungRepository.auth("test1", "123456"));
            //kiểm tra cả username và password không hợp lệ
            Assert.AreEqual(null, nguoiDungRepository.auth("test100", "123456"));
        }
        [Test]
        public void doiMatKhau()
        {
            ////kiểm tra Id người dùng hợp lệ
            //Assert.AreEqual(true, nguoiDungRepository.doiMatKhau(2,"123"));

            //kiểm tra Id người dùng không hợp lệ
            Assert.AreEqual(false, nguoiDungRepository.doiMatKhau(100, "1234"));

        }
    }
}
