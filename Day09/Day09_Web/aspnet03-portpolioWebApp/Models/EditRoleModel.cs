using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aspnet02_boardapp.Models
{
    public class EditRoleModel
    {

        public string Id { get; set; }

        [DisplayName("권한이름")]
        [Required(ErrorMessage = "권한이름이 없습니다.")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
        public EditRoleModel() 
        {
            Users = new List<string>();
        }

    }
}
