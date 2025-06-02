using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
	public class Category
	{
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Kategori Adı Boş geçilemez")]
        [StringLength(20,ErrorMessage ="Lütfen 20 Karakterden Fazla isim Girişi Yapmayın!")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
