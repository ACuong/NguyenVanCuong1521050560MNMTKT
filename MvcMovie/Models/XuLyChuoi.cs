using System;

namespace MvcMovie.Models
{
    public class XuLyChuoi
    {   
         public string Xuly (string s) //" mã nguồn mở"
         {            
            // chuyen ky tu dau tien cua cac chuoi sang in hoa
            //xoá bỏ các khoảng trắng thừa trong chuỗi
            // ap dung cho tat ca  thuoc tinh co kieu string cua doi tuong
            // ví dụ: " mã nguồn mở" =>"Mã Nguồn Mở"
            if (String.IsNullOrEmpty(s))   
            return s;  
            string newstring = "";   
            
            //lấy danh sách các từ  
            string[] words = s.Split(' '); // hàm Split tách ra một bảng gồm các chuỗi con được ngăn cách bởi ký tự - cụ thể ở đây khoảng trắng " "
            // ở đây tách ra 3 chuỗi con " mã" "nguồn" "mở"
            foreach (string word in words)  // duyệt từng chuỗi trong bảng chuỗi words
            {       
                if (word.Trim() != "")  //.Trim() loại bỏ khoảng trắng thừa dầu cuối
                {  
                    if (word.Length > 1)  // độ dài chuỗi nếu lớn hơn 1
                        newstring += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";  // viết hoa chữ cái đầu và viết thường tất cả chữ cái đằng sau của chuỗi
                        // hàm ToUpper, hàm Tolower In hoa, và in thường
                        // Substring tách chuỗi, Substring(khoảng cách từ trái sang, số ký tự lấy từ trái trang)
                        // Substring(1) lấy toàn bộ từ bên trái sang trừ ký tự đầu
                        // Substring(0, 1) lấy một ký tự đầu tiên
                    else  // Chuỗi chỉ một ký tự thì viết hoa và thêm khoảng trắng luôn
                        newstring += word.ToUpper() + " "; 
                }  
            }  
            return newstring.Trim(); // trả về biến newstring đã trim - cắt thừa các khoảng trắng
         }

    }
}