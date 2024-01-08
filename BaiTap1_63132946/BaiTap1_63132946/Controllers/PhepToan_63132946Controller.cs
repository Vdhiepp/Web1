using BaiTap1_63132946.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap1_63132946.Controllers
{
    public class PhepToan_63132946Controller : Controller
    {
        // GET: PhepToan_63132946
        public ActionResult Index() // Là một p/thức có sẵn, ban đầu hiển thị giao diện trước, sau khi ấn submit sẽ xử lý p/thức 2
        {
            return View();
        }

        public ActionResult UseRequest() // Đây là một phương thức action (hành động) của MVC (Model-View-Controller) được định nghĩa để xử lý yêu cầu GET đối với tài nguyên tương ứng với URL mà nó được liên kết. Nó trả về một ActionResult, cho phép bạn trả về một giao diện người dùng
        {
            return View();
        }

        // Cách 1
        [HttpPost] // [HttpPost] public ActionResult UseRequest(string pt): Đây là một phương thức action được đánh dấu bằng [HttpPost]. Điều này đồng nghĩa với việc phương thức này chỉ xử lý yêu cầu POST (chẳng hạn khi người dùng ấn nút submit trên một biểu mẫu).
        public ActionResult UseRequest(string pt)
        {
            double a = double.Parse(Request["a"]); // Nó lấy giá trị của a từ yêu cầu bằng cách sử dụng Request["a"], sau đó ép kiểu a thành số thực.
            double b = double.Parse(Request["b"]); // Nó lấy giá trị của b từ yêu cầu bằng cách sử dụng Request["b"], sau đó ép kiểu b thành số thực.
            // a, b là tên(name) của các thẻ html để nhập dữ liệu cho a, b
            // Request[""]: Trả về kiểu chuỗi ký tự nên phải ép kiểu
            pt = Request["pt"].ToString(); // Nó lấy giá trị của pt từ yêu cầu bằng cách sử dụng Request["pt"].
            switch (pt)
            {
                case "+": ViewBag.KQ = a + b; break; // Kết quả của phép tính được gán vào ViewBag.KQ. ViewBag là một cơ chế trong ASP.NET MVC cho phép bạn truyền dữ liệu từ controller đến view để hiển thị kết quả lên giao diện người dùng.
                case "-": ViewBag.KQ = a - b; break;
                case "*": ViewBag.KQ = a * b; break;
                case "/":
                    if (b == 0) ViewBag.KQ = "Không chia được cho 0";
                    else ViewBag.KQ = a / b; break;
            }
            return View();
        }
        // Tóm lại, UseRequest là một phương thức trong controller có nhiệm vụ xử lý dữ liệu được gửi từ biểu mẫu sau khi người dùng ấn nút submit, thực hiện các phép tính toán và gán kết quả cho ViewBag để hiển thị lên giao diện người dùng.

        // Cách 2
        public ActionResult UseArguments()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UseArguments(double a, double b, string pt = "+")
        {
            switch (pt)
            {
                case "+": ViewBag.KQ = a + b; break;
                case "-": ViewBag.KQ = a - b; break;
                case "*": ViewBag.KQ = a * b; break;
                case "/":
                    if (b == 0) ViewBag.KQ = "Không chia được cho 0";
                    else ViewBag.KQ = a / b; break;
            }
            return View();
        }

        // Cách 3
        public ActionResult UseFormCollection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UseFormCollection(FormCollection f)
        {
            double a = double.Parse(f["a"]);//Chuyển đổi chuỗi sang số thực
            double b = double.Parse(f["b"]);
            string pt = f["pt"].ToString();
            switch (pt)
            {
                case "+": ViewBag.KQ = a + b; break;
                case "-": ViewBag.KQ = a - b; break;
                case "*": ViewBag.KQ = a * b; break;
                case "/":
                    if (b == 0) ViewBag.KQ = "Không chia được cho 0";
                    else ViewBag.KQ = a / b; break;
            }
            return View();
        }

        // Cách 4
        [HttpPost]
        public ActionResult Index(CallModels cal)
        {
            switch (cal.pt)
            {
                case "+": ViewBag.KQ = cal.a + cal.b; break;
                case "-": ViewBag.KQ = cal.a - cal.b; break;
                case "*": ViewBag.KQ = cal.a * cal.b; break;
                case "/":
                    if (cal.b == 0) ViewBag.KQ = "Không chia được cho 0";
                    else ViewBag.KQ = cal.a / cal.b; break;
            }
            return View();
        }
    }
}