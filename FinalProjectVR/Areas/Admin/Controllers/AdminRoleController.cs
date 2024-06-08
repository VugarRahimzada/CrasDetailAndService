using DTOLayer.MembershipDTO;
using EntityLayer.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Creator")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminRoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDTOs roleDto)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole { Name = roleDto.Name };
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(roleDto);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            RoleUpdateDTOs roles = new RoleUpdateDTOs()
            {
                Id = value.Id,
                Name = value.Name,
            };

            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateDTOs roleDto)
        {
            if (ModelState.IsValid)
            {
                var values = _roleManager.Roles.Where(x => x.Id == roleDto.Id).FirstOrDefault();

                values.Name = roleDto.Name;
                var result = await _roleManager.UpdateAsync(values);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(roleDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]

        public IActionResult UserRoleList()
        {
            var value = _userManager.Users.ToList();

            return View(value);
        }


        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignDTOs> model = new List<RoleAssignDTOs>();
            foreach (var item in roles)
            {
                RoleAssignDTOs m = new RoleAssignDTOs()
                {
                    RoleId = item.Id,
                    Name = item.Name,
                    Exists = userRoles.Contains(item.Name)

                };
                model.Add(m);
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignDTOs> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);

            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }

            }
            return RedirectToAction("UserRoleList");
        }
    }
}
