using FOOD_APP_JSB_2.Data.Enums;

namespace FOOD_APP_JSB_2.Models;

public class User : BaseModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Role Role { get; set; }

    public IEnumerable<UserFeature> UserFeatures { get; set; }
}