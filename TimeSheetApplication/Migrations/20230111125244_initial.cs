using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheetApplication.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeEmail = table.Column<string>(name: "Employee_Email", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EmployeePassword = table.Column<string>(name: "Employee_Password", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EmployeeID = table.Column<int>(name: "Employee_ID", type: "int", nullable: false),
                    EmployeeFirstName = table.Column<string>(name: "Employee_FirstName", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EmployeeLastName = table.Column<string>(name: "Employee_LastName", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EmployeeDesignation = table.Column<string>(name: "Employee_Designation", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EmployeeJoiningDate = table.Column<DateTime>(name: "Employee_JoiningDate", type: "date", nullable: false),
                    EmployeeLeavingDate = table.Column<DateTime>(name: "Employee_LeavingDate", type: "date", nullable: true),
                    EmployeeStatus = table.Column<byte>(name: "Employee_Status", type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__616BAD36D173ED57", x => x.EmployeeEmail);
                });

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    TaskId = table.Column<int>(name: "Task_Id", type: "int", nullable: false),
                    EmployeeEmail = table.Column<string>(name: "Employee_Email", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TaskDetails = table.Column<string>(name: "Task_Details", type: "text", nullable: false),
                    TaskCraeted = table.Column<DateTime>(name: "Task_Craeted", type: "datetime", nullable: false),
                    TaskDeadline = table.Column<DateTime>(name: "Task_Deadline", type: "datetime", nullable: false),
                    TaskCompletion = table.Column<DateTime>(name: "Task_Completion", type: "datetime", nullable: true),
                    TaskType = table.Column<byte>(name: "Task_Type", type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskList__716F4AEDBB0F4CA2", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK__TaskList__Employ__5CD6CB2B",
                        column: x => x.EmployeeEmail,
                        principalTable: "Employees",
                        principalColumn: "Employee_Email");
                });

            migrationBuilder.CreateTable(
                name: "TimeSheet",
                columns: table => new
                {
                    TimeSheetId = table.Column<int>(name: "TimeSheet_Id", type: "int", nullable: false),
                    EmployeeEmail = table.Column<string>(name: "Employee_Email", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TaskId = table.Column<int>(name: "Task_Id", type: "int", nullable: false),
                    ApprovalStatus = table.Column<byte>(name: "Approval_Status", type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TimeShee__D0EF8CC805B24816", x => x.TimeSheetId);
                    table.ForeignKey(
                        name: "FK__TimeSheet__Emplo__5FB337D6",
                        column: x => x.EmployeeEmail,
                        principalTable: "Employees",
                        principalColumn: "Employee_Email");
                    table.ForeignKey(
                        name: "FK__TimeSheet__Task___60A75C0F",
                        column: x => x.TaskId,
                        principalTable: "TaskList",
                        principalColumn: "Task_Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__78113480F6383760",
                table: "Employees",
                column: "Employee_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_Employee_Email",
                table: "TaskList",
                column: "Employee_Email");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheet_Employee_Email",
                table: "TimeSheet",
                column: "Employee_Email");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheet_Task_Id",
                table: "TimeSheet",
                column: "Task_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSheet");

            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
