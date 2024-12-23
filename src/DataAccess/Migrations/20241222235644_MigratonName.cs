using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigratonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83FEA0FBF0E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReportTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reportTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReportTy__3213E83F6EF6437C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3213E83F96F0A11D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    subjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__3213E83FA85B43B7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskCate__3213E83F1DA79648", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskPriorities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    priorityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskPrio__3213E83FB093C4AF", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskStat__3213E83FA02D9194", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskType__3213E83F54278A26", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teachers__3213E83FE762DBC4", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F813C9834", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectInfo",
                columns: table => new
                {
                    subjectId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false),
                    classroom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubjectI__3213E83F402CB8F9", x => x.subjectId);
                    table.ForeignKey(
                        name: "FK_SubjectInfo_Subjects",
                        column: x => x.subjectId,
                        principalTable: "Subjects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__SubjectIn__teach__619B8048",
                        column: x => x.teacherId,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    reportTypeId = table.Column<int>(type: "int", nullable: false),
                    reportPeriodStart = table.Column<DateOnly>(type: "date", nullable: false),
                    reportPeriodEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reports__3213E83FAA8DF638", x => x.id);
                    table.ForeignKey(
                        name: "FK__Reports__reportT__5441852A",
                        column: x => x.reportTypeId,
                        principalTable: "ReportTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Reports__userId__534D60F1",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesOfUser",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesOfUser", x => x.userId);
                    table.ForeignKey(
                        name: "FK_RolesOfUser_Roles",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RolesOfUser_Users",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    priorityId = table.Column<int>(type: "int", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deadline = table.Column<DateTime>(type: "datetime", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tasks__3213E83F3283DBB6", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tasks_Subjects",
                        column: x => x.subjectId,
                        principalTable: "Subjects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tasks__categoryI__37A5467C",
                        column: x => x.categoryId,
                        principalTable: "TaskCategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tasks__priorityI__35BCFE0A",
                        column: x => x.priorityId,
                        principalTable: "TaskPriorities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tasks__statusId__36B12243",
                        column: x => x.statusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tasks__typeId__34C8D9D1",
                        column: x => x.typeId,
                        principalTable: "TaskTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tasks__userId__33D4B598",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    placeOfStudy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserInfo__3213E83F5305A951", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__UserInfo__id__286302EC",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    notificationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83F81665EB3", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__statu__4D94879B",
                        column: x => x.statusId,
                        principalTable: "NotificationStatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Notificat__taskI__4CA06362",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShortTaskDescriptions",
                columns: table => new
                {
                    taskId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskDesc__3213E83F1A6BFEF5", x => x.taskId);
                    table.ForeignKey(
                        name: "FK__TaskDescr__taskI__3A81B327",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskAttachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskAtta__3213E83F70439DD9", x => x.id);
                    table.ForeignKey(
                        name: "FK__TaskAttac__taskI__3E52440B",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskComm__3213E83FBC7AB98E", x => x.id);
                    table.ForeignKey(
                        name: "FK__TaskComme__taskI__47DBAE45",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskPrioritiesHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    oldPriority = table.Column<int>(type: "int", nullable: false),
                    newPriority = table.Column<int>(type: "int", nullable: false),
                    changedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPrioritiesHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_TaskPrioritiesHistory_TaskPriorities",
                        column: x => x.oldPriority,
                        principalTable: "TaskPriorities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TaskPrioritiesHistory_TaskPriorities1",
                        column: x => x.newPriority,
                        principalTable: "TaskPriorities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TaskPrioritiesHistory_Tasks",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TaskStatusHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    oldStatusId = table.Column<int>(type: "int", nullable: false),
                    newStatusId = table.Column<int>(type: "int", nullable: false),
                    changedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskStat__3213E83F871CFE96", x => x.id);
                    table.ForeignKey(
                        name: "FK_TaskStatusHistory_TaskStatuses",
                        column: x => x.oldStatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TaskStatusHistory_TaskStatuses1",
                        column: x => x.newStatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__TaskStatu__taskI__4222D4EF",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "roleName" },
                values: new object[,]
                {
                    { -2, "Администратор" },
                    { -1, "Студент" }
                });

            migrationBuilder.InsertData(
                table: "TaskCategories",
                columns: new[] { "id", "categoryName" },
                values: new object[,]
                {
                    { -6, "Прогулка" },
                    { -5, "Поход в магазин" },
                    { -4, "Дела по дому" },
                    { -3, "Письменная работа" },
                    { -2, "Презентация" },
                    { -1, "Проект" }
                });

            migrationBuilder.InsertData(
                table: "TaskPriorities",
                columns: new[] { "id", "priorityName" },
                values: new object[,]
                {
                    { -3, "Высокий" },
                    { -2, "Средний" },
                    { -1, "Низкий" }
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "id", "statusName" },
                values: new object[,]
                {
                    { -6, "Отменена" },
                    { -5, "Отложена" },
                    { -4, "Просрочена" },
                    { -3, "Завершена" },
                    { -2, "В процессе" },
                    { -1, "Не начата" }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "id", "typeName" },
                values: new object[,]
                {
                    { -2, "Внеучебная" },
                    { -1, "Учебная" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_statusId",
                table: "Notifications",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_taskId",
                table: "Notifications",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_reportTypeId",
                table: "Reports",
                column: "reportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_userId",
                table: "Reports",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesOfUser_roleId",
                table: "RolesOfUser",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInfo_teacherId",
                table: "SubjectInfo",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_taskId",
                table: "TaskAttachments",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_taskId",
                table: "TaskComments",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskPrioritiesHistory_newPriority",
                table: "TaskPrioritiesHistory",
                column: "newPriority");

            migrationBuilder.CreateIndex(
                name: "IX_TaskPrioritiesHistory_oldPriority",
                table: "TaskPrioritiesHistory",
                column: "oldPriority");

            migrationBuilder.CreateIndex(
                name: "IX_TaskPrioritiesHistory_taskId",
                table: "TaskPrioritiesHistory",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_categoryId",
                table: "Tasks",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_priorityId",
                table: "Tasks",
                column: "priorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_statusId",
                table: "Tasks",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_subjectId",
                table: "Tasks",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_typeId",
                table: "Tasks",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_userId",
                table: "Tasks",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatusHistory_newStatusId",
                table: "TaskStatusHistory",
                column: "newStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatusHistory_oldStatusId",
                table: "TaskStatusHistory",
                column: "oldStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatusHistory_taskId",
                table: "TaskStatusHistory",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E6164E5B8A0A6",
                table: "Users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "RolesOfUser");

            migrationBuilder.DropTable(
                name: "ShortTaskDescriptions");

            migrationBuilder.DropTable(
                name: "SubjectInfo");

            migrationBuilder.DropTable(
                name: "TaskAttachments");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "TaskPrioritiesHistory");

            migrationBuilder.DropTable(
                name: "TaskStatusHistory");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "NotificationStatuses");

            migrationBuilder.DropTable(
                name: "ReportTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "TaskCategories");

            migrationBuilder.DropTable(
                name: "TaskPriorities");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
