using Abp.Application.Navigation;
using Abp.Localization;
using JD.CRS.Authorization;

namespace JD.CRS.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class CRSNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem( //一级菜单 - 首页
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("Home"),
                        url: "",
                        icon: "home",
                        requiredPermissionName: PermissionNames.Pages_Home
                    )
                )
                .AddItem( //一级菜单 - 基础数据
                    new MenuItemDefinition(
                        "Data",
                        L("Data"),
                        icon: "storage"
                    ).AddItem( //二级菜单 - 办公室设置
                        new MenuItemDefinition(
                            PageNames.Office,
                            L("Office"),
                            url: "Office",
                            requiredPermissionName: PermissionNames.Pages_Office
                        )
                    ).AddItem( //二级菜单 - 院系设置
                        new MenuItemDefinition(
                            PageNames.Department,
                            L("Department"),
                            url: "Department",
                            requiredPermissionName: PermissionNames.Pages_Department
                        )
                    ).AddItem( //二级菜单 - 课程设置
                        new MenuItemDefinition(
                            PageNames.Course,
                            L("Course"),
                            url: "Course",
                            requiredPermissionName: PermissionNames.Pages_Course
                        )
                    ).AddItem( //二级菜单 - 教职员设置
                        new MenuItemDefinition(
                            PageNames.Instructor,
                            L("Instructor"),
                            url: "Instructor",
                            requiredPermissionName: PermissionNames.Pages_Instructor
                        )
                    ).AddItem( //二级菜单 - 学生设置
                        new MenuItemDefinition(
                            PageNames.Student,
                            L("Student"),
                            url: "Student",
                            requiredPermissionName: PermissionNames.Pages_Student
                        )
                    )
                )
                .AddItem( //一级菜单 - 综合服务
                    new MenuItemDefinition(
                        "Service",
                        L("Service"),
                        icon: "business"
                    ).AddItem( //二级菜单 - 教职员办公室设置
                        new MenuItemDefinition(
                            PageNames.OfficeInstructor,
                            L("OfficeInstructor"),
                            url: "OfficeInstructor",
                            requiredPermissionName: PermissionNames.Pages_OfficeInstructor
                        )
                    ).AddItem( //二级菜单 - 院系主任设置
                        new MenuItemDefinition(
                            PageNames.DepartmentInstructor,
                            L("DepartmentInstructor"),
                            url: "DepartmentInstructor",
                            requiredPermissionName: PermissionNames.Pages_DepartmentInstructor
                        )
                    ).AddItem( //二级菜单 - 院系课程设置
                        new MenuItemDefinition(
                            PageNames.DepartmentCourse,
                            L("DepartmentCourse"),
                            url: "DepartmentCourse",
                            requiredPermissionName: PermissionNames.Pages_DepartmentCourse
                        )
                    ).AddItem( //二级菜单 - 教职员课程设置
                        new MenuItemDefinition(
                            PageNames.InstructorCourse,
                            L("InstructorCourse"),
                            url: "InstructorCourse",
                            requiredPermissionName: PermissionNames.Pages_InstructorCourse
                        )
                    ).AddItem( //二级菜单 - 学生课程设置
                        new MenuItemDefinition(
                            PageNames.StudentCourse,
                            L("StudentCourse"),
                            url: "StudentCourse",
                            requiredPermissionName: PermissionNames.Pages_StudentCourse
                        )
                    )
                )
                .AddItem( //一级菜单 - 管理报表
                    new MenuItemDefinition(
                        "Report",
                        L("Report"),
                        icon: "poll"
                    ).AddItem( //二级菜单 - 办公室报表
                        new MenuItemDefinition(
                            PageNames.OfficeReport,
                            L("OfficeReport"),
                            url: "OfficeReport",
                            requiredPermissionName: PermissionNames.Pages_OfficeReport
                        )
                    ).AddItem( //二级菜单 - 院系报表
                        new MenuItemDefinition(
                            PageNames.DepartmentReport,
                            L("DepartmentReport"),
                            url: "DepartmentReport",
                            requiredPermissionName: PermissionNames.Pages_DepartmentReport
                        )
                    ).AddItem( //二级菜单 - 课程报表
                        new MenuItemDefinition(
                            PageNames.CourseReport,
                            L("CourseReport"),
                            url: "CourseReport",
                            requiredPermissionName: PermissionNames.Pages_CourseReport
                        )
                    ).AddItem( //二级菜单 - 教职员报表
                        new MenuItemDefinition(
                            PageNames.InstructorReport,
                            L("InstructorReport"),
                            url: "InstructorReport",
                            requiredPermissionName: PermissionNames.Pages_InstructorReport
                        )
                    ).AddItem( //二级菜单 - 学生报表
                        new MenuItemDefinition(
                            PageNames.StudentReport,
                            L("StudentReport"),
                            url: "StudentReport",
                            requiredPermissionName: PermissionNames.Pages_StudentReport
                        )
                    )
                )
                .AddItem( //一级菜单 - 系统设置
                    new MenuItemDefinition(
                        "Setting",
                        L("Setting"),
                        icon: "settings"
                    ).AddItem( //二级菜单 - 租户管理
                        new MenuItemDefinition(
                            PageNames.Tenants,
                            L("Tenants"),
                            url: "Tenants",
                            requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                    ).AddItem( //二级菜单 - 用户管理
                        new MenuItemDefinition(
                            PageNames.Users,
                            L("Users"),
                            url: "Users",
                            requiredPermissionName: PermissionNames.Pages_Users
                        )
                    ).AddItem( //二级菜单 - 角色管理
                        new MenuItemDefinition(
                            PageNames.Roles,
                            L("Roles"),
                            url: "Roles",
                            requiredPermissionName: PermissionNames.Pages_Roles
                        )
                    )
                )
                .AddItem( //一级菜单 - 关于
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "info",
                        requiresAuthentication: true
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CRSConsts.LocalizationSourceName);
        }
    }
}
