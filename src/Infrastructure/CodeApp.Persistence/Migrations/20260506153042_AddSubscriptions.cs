using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserStepQuestions_AspNetUsers_AppUserId",
                table: "AppUserStepQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserStepQuestions_StepQuestions_StepQuestionId",
                table: "AppUserStepQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Avatars_AvatarId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Languages_LanguageId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_StepQuestions_StepQuestionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Languages_LanguageId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStreaks_AspNetUsers_UserId",
                table: "UserStreaks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStreaks",
                table: "UserStreaks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StepQuestions",
                table: "StepQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avatars",
                table: "Avatars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserStepQuestions",
                table: "AppUserStepQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "UserStreaks",
                newName: "userstreaks");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "subjects");

            migrationBuilder.RenameTable(
                name: "StepQuestions",
                newName: "stepquestions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "questions");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "languages");

            migrationBuilder.RenameTable(
                name: "Avatars",
                newName: "avatars");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "aspnetusertokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "aspnetusers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "aspnetuserroles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "aspnetuserlogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "aspnetuserclaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "aspnetroles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "aspnetroleclaims");

            migrationBuilder.RenameTable(
                name: "AppUserStepQuestions",
                newName: "appuserstepquestions");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "answers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "userstreaks",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "userstreaks",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "StreakStartDate",
                table: "userstreaks",
                newName: "streakstartdate");

            migrationBuilder.RenameColumn(
                name: "LongestStreak",
                table: "userstreaks",
                newName: "longeststreak");

            migrationBuilder.RenameColumn(
                name: "LastActivityDate",
                table: "userstreaks",
                newName: "lastactivitydate");

            migrationBuilder.RenameColumn(
                name: "CurrentStreak",
                table: "userstreaks",
                newName: "currentstreak");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "userstreaks",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "userstreaks",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_UserStreaks_UserId",
                table: "userstreaks",
                newName: "ix_userstreaks_userid");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "subjects",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "subjects",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "subjects",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "subjects",
                newName: "languageid");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "subjects",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "subjects",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "subjects",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_LanguageId",
                table: "subjects",
                newName: "ix_subjects_languageid");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "stepquestions",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "stepquestions",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "StepNumber",
                table: "stepquestions",
                newName: "stepnumber");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "stepquestions",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "stepquestions",
                newName: "languageid");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "stepquestions",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "stepquestions",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "stepquestions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "questions",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "StepQuestionId",
                table: "questions",
                newName: "stepquestionid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "questions",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "questions",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "questions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "questions",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "questions",
                newName: "languageid");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "questions",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "questions",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "questions",
                newName: "correctanswer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "questions",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_StepQuestionId",
                table: "questions",
                newName: "ix_questions_stepquestionid");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_LanguageId",
                table: "questions",
                newName: "ix_questions_languageid");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "languages",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "languages",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "languages",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "languages",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "languages",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "languages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "avatars",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "avatars",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "avatars",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "avatars",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "avatars",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "avatars",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "aspnetusertokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "aspnetusertokens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "aspnetusertokens",
                newName: "loginprovider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "aspnetusertokens",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "aspnetusers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "aspnetusers",
                newName: "twofactorenabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "aspnetusers",
                newName: "securitystamp");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "aspnetusers",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenEndDate",
                table: "aspnetusers",
                newName: "refreshtokenenddate");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "aspnetusers",
                newName: "refreshtoken");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "aspnetusers",
                newName: "phonenumberconfirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "aspnetusers",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "aspnetusers",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "aspnetusers",
                newName: "normalizedusername");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "aspnetusers",
                newName: "normalizedemail");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "aspnetusers",
                newName: "lockoutend");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "aspnetusers",
                newName: "lockoutenabled");

            migrationBuilder.RenameColumn(
                name: "LastLoggedSession",
                table: "aspnetusers",
                newName: "lastloggedsession");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "aspnetusers",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "aspnetusers",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "aspnetusers",
                newName: "emailconfirmed");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "aspnetusers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "aspnetusers",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "aspnetusers",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "AvatarId",
                table: "aspnetusers",
                newName: "avatarid");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "aspnetusers",
                newName: "accessfailedcount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "aspnetusers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "UserNameIndex",
                table: "aspnetusers",
                newName: "usernameindex");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AvatarId",
                table: "aspnetusers",
                newName: "ix_aspnetusers_avatarid");

            migrationBuilder.RenameIndex(
                name: "EmailIndex",
                table: "aspnetusers",
                newName: "emailindex");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "aspnetuserroles",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "aspnetuserroles",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "aspnetuserroles",
                newName: "ix_aspnetuserroles_roleid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "aspnetuserlogins",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "aspnetuserlogins",
                newName: "providerdisplayname");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "aspnetuserlogins",
                newName: "providerkey");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "aspnetuserlogins",
                newName: "loginprovider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "aspnetuserlogins",
                newName: "ix_aspnetuserlogins_userid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "aspnetuserclaims",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "aspnetuserclaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "aspnetuserclaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "aspnetuserclaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "aspnetuserclaims",
                newName: "ix_aspnetuserclaims_userid");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "aspnetroles",
                newName: "normalizedname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "aspnetroles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "aspnetroles",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "aspnetroles",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "RoleNameIndex",
                table: "aspnetroles",
                newName: "rolenameindex");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "aspnetroleclaims",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "aspnetroleclaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "aspnetroleclaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "aspnetroleclaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "aspnetroleclaims",
                newName: "ix_aspnetroleclaims_roleid");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "appuserstepquestions",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "StepQuestionId",
                table: "appuserstepquestions",
                newName: "stepquestionid");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "appuserstepquestions",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "appuserstepquestions",
                newName: "languageid");

            migrationBuilder.RenameColumn(
                name: "CurrentStepNumber",
                table: "appuserstepquestions",
                newName: "currentstepnumber");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "appuserstepquestions",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "appuserstepquestions",
                newName: "appuserid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "appuserstepquestions",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserStepQuestions_StepQuestionId",
                table: "appuserstepquestions",
                newName: "ix_appuserstepquestions_stepquestionid");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserStepQuestions_AppUserId",
                table: "appuserstepquestions",
                newName: "ix_appuserstepquestions_appuserid");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "answers",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "answers",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "answers",
                newName: "questionid");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "answers",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "AnswerName",
                table: "answers",
                newName: "answername");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "answers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "answers",
                newName: "ix_answers_questionid");

            migrationBuilder.AddColumn<DateTime>(
                name: "premiumuntilutc",
                table: "aspnetusers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subscriptiontier",
                table: "aspnetusers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_userstreaks",
                table: "userstreaks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_subjects",
                table: "subjects",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_stepquestions",
                table: "stepquestions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_questions",
                table: "questions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_languages",
                table: "languages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_avatars",
                table: "avatars",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetusertokens",
                table: "aspnetusertokens",
                columns: new[] { "userid", "loginprovider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetusers",
                table: "aspnetusers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserroles",
                table: "aspnetuserroles",
                columns: new[] { "userid", "roleid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserlogins",
                table: "aspnetuserlogins",
                columns: new[] { "loginprovider", "providerkey" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserclaims",
                table: "aspnetuserclaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetroles",
                table: "aspnetroles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetroleclaims",
                table: "aspnetroleclaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_appuserstepquestions",
                table: "appuserstepquestions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_answers",
                table: "answers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "usersubscriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<string>(type: "text", nullable: false),
                    provider = table.Column<int>(type: "integer", nullable: false),
                    tier = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    originaltransactionid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    transactionid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    purchasedateutc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiresdateutc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastverifiedutc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rawpayload = table.Column<string>(type: "text", nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usersubscriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_usersubscriptions_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_usersubscriptions_provider_originaltransactionid",
                table: "usersubscriptions",
                columns: new[] { "provider", "originaltransactionid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_usersubscriptions_userid",
                table: "usersubscriptions",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "fk_answers_questions_questionid",
                table: "answers",
                column: "questionid",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_appuserstepquestions_aspnetusers_appuserid",
                table: "appuserstepquestions",
                column: "appuserid",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_appuserstepquestions_stepquestions_stepquestionid",
                table: "appuserstepquestions",
                column: "stepquestionid",
                principalTable: "stepquestions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_roleid",
                table: "aspnetroleclaims",
                column: "roleid",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserclaims_aspnetusers_userid",
                table: "aspnetuserclaims",
                column: "userid",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserlogins_aspnetusers_userid",
                table: "aspnetuserlogins",
                column: "userid",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_roleid",
                table: "aspnetuserroles",
                column: "roleid",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_aspnetusers_userid",
                table: "aspnetuserroles",
                column: "userid",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetusers_avatars_avatarid",
                table: "aspnetusers",
                column: "avatarid",
                principalTable: "avatars",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetusertokens_aspnetusers_userid",
                table: "aspnetusertokens",
                column: "userid",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questions_languages_languageid",
                table: "questions",
                column: "languageid",
                principalTable: "languages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questions_stepquestions_stepquestionid",
                table: "questions",
                column: "stepquestionid",
                principalTable: "stepquestions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_subjects_languages_languageid",
                table: "subjects",
                column: "languageid",
                principalTable: "languages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_userstreaks_aspnetusers_userid",
                table: "userstreaks",
                column: "userid",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_answers_questions_questionid",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "fk_appuserstepquestions_aspnetusers_appuserid",
                table: "appuserstepquestions");

            migrationBuilder.DropForeignKey(
                name: "fk_appuserstepquestions_stepquestions_stepquestionid",
                table: "appuserstepquestions");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_roleid",
                table: "aspnetroleclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserclaims_aspnetusers_userid",
                table: "aspnetuserclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserlogins_aspnetusers_userid",
                table: "aspnetuserlogins");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_roleid",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_aspnetusers_userid",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetusers_avatars_avatarid",
                table: "aspnetusers");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetusertokens_aspnetusers_userid",
                table: "aspnetusertokens");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_languages_languageid",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_stepquestions_stepquestionid",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "fk_subjects_languages_languageid",
                table: "subjects");

            migrationBuilder.DropForeignKey(
                name: "fk_userstreaks_aspnetusers_userid",
                table: "userstreaks");

            migrationBuilder.DropTable(
                name: "usersubscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_userstreaks",
                table: "userstreaks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_subjects",
                table: "subjects");

            migrationBuilder.DropPrimaryKey(
                name: "pk_stepquestions",
                table: "stepquestions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_questions",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_languages",
                table: "languages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_avatars",
                table: "avatars");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetusertokens",
                table: "aspnetusertokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetusers",
                table: "aspnetusers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserroles",
                table: "aspnetuserroles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserlogins",
                table: "aspnetuserlogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserclaims",
                table: "aspnetuserclaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetroles",
                table: "aspnetroles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetroleclaims",
                table: "aspnetroleclaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_appuserstepquestions",
                table: "appuserstepquestions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_answers",
                table: "answers");

            migrationBuilder.DropColumn(
                name: "premiumuntilutc",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "subscriptiontier",
                table: "aspnetusers");

            migrationBuilder.RenameTable(
                name: "userstreaks",
                newName: "UserStreaks");

            migrationBuilder.RenameTable(
                name: "subjects",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "stepquestions",
                newName: "StepQuestions");

            migrationBuilder.RenameTable(
                name: "questions",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "languages",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "avatars",
                newName: "Avatars");

            migrationBuilder.RenameTable(
                name: "aspnetusertokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "aspnetusers",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "aspnetuserroles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "aspnetuserlogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "aspnetuserclaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "aspnetroles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "aspnetroleclaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "appuserstepquestions",
                newName: "AppUserStepQuestions");

            migrationBuilder.RenameTable(
                name: "answers",
                newName: "Answers");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "UserStreaks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "UserStreaks",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "streakstartdate",
                table: "UserStreaks",
                newName: "StreakStartDate");

            migrationBuilder.RenameColumn(
                name: "longeststreak",
                table: "UserStreaks",
                newName: "LongestStreak");

            migrationBuilder.RenameColumn(
                name: "lastactivitydate",
                table: "UserStreaks",
                newName: "LastActivityDate");

            migrationBuilder.RenameColumn(
                name: "currentstreak",
                table: "UserStreaks",
                newName: "CurrentStreak");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "UserStreaks",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserStreaks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_userstreaks_userid",
                table: "UserStreaks",
                newName: "IX_UserStreaks_UserId");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "Subjects",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Subjects",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Subjects",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "languageid",
                table: "Subjects",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Subjects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Subjects",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_subjects_languageid",
                table: "Subjects",
                newName: "IX_Subjects_LanguageId");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "StepQuestions",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "StepQuestions",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "stepnumber",
                table: "StepQuestions",
                newName: "StepNumber");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "StepQuestions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "languageid",
                table: "StepQuestions",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "StepQuestions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "StepQuestions",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "StepQuestions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "Questions",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "stepquestionid",
                table: "Questions",
                newName: "StepQuestionId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Questions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "Questions",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Questions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Questions",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "languageid",
                table: "Questions",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Questions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Questions",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "correctanswer",
                table: "Questions",
                newName: "CorrectAnswer");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Questions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_questions_stepquestionid",
                table: "Questions",
                newName: "IX_Questions_StepQuestionId");

            migrationBuilder.RenameIndex(
                name: "ix_questions_languageid",
                table: "Questions",
                newName: "IX_Questions_LanguageId");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "Languages",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Languages",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Languages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Languages",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Languages",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Languages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "Avatars",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Avatars",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "Avatars",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Avatars",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Avatars",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Avatars",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "AspNetUserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetUserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                table: "AspNetUserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "twofactorenabled",
                table: "AspNetUsers",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "securitystamp",
                table: "AspNetUsers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "AspNetUsers",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "refreshtokenenddate",
                table: "AspNetUsers",
                newName: "RefreshTokenEndDate");

            migrationBuilder.RenameColumn(
                name: "refreshtoken",
                table: "AspNetUsers",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "phonenumberconfirmed",
                table: "AspNetUsers",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "AspNetUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "AspNetUsers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "normalizedusername",
                table: "AspNetUsers",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalizedemail",
                table: "AspNetUsers",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "lockoutend",
                table: "AspNetUsers",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockoutenabled",
                table: "AspNetUsers",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "lastloggedsession",
                table: "AspNetUsers",
                newName: "LastLoggedSession");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "AspNetUsers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "emailconfirmed",
                table: "AspNetUsers",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "AspNetUsers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "AspNetUsers",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "avatarid",
                table: "AspNetUsers",
                newName: "AvatarId");

            migrationBuilder.RenameColumn(
                name: "accessfailedcount",
                table: "AspNetUsers",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "usernameindex",
                table: "AspNetUsers",
                newName: "UserNameIndex");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetusers_avatarid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AvatarId");

            migrationBuilder.RenameIndex(
                name: "emailindex",
                table: "AspNetUsers",
                newName: "EmailIndex");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "AspNetUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserroles_roleid",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "providerdisplayname",
                table: "AspNetUserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "providerkey",
                table: "AspNetUserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                table: "AspNetUserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserlogins_userid",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                table: "AspNetUserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                table: "AspNetUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserclaims_userid",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "normalizedname",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "AspNetRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "rolenameindex",
                table: "AspNetRoles",
                newName: "RoleNameIndex");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "AspNetRoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                table: "AspNetRoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                table: "AspNetRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetroleclaims_roleid",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "AppUserStepQuestions",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "stepquestionid",
                table: "AppUserStepQuestions",
                newName: "StepQuestionId");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "AppUserStepQuestions",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "languageid",
                table: "AppUserStepQuestions",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "currentstepnumber",
                table: "AppUserStepQuestions",
                newName: "CurrentStepNumber");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "AppUserStepQuestions",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "appuserid",
                table: "AppUserStepQuestions",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AppUserStepQuestions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_appuserstepquestions_stepquestionid",
                table: "AppUserStepQuestions",
                newName: "IX_AppUserStepQuestions_StepQuestionId");

            migrationBuilder.RenameIndex(
                name: "ix_appuserstepquestions_appuserid",
                table: "AppUserStepQuestions",
                newName: "IX_AppUserStepQuestions_AppUserId");

            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "Answers",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Answers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "questionid",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Answers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "answername",
                table: "Answers",
                newName: "AnswerName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Answers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_answers_questionid",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStreaks",
                table: "UserStreaks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StepQuestions",
                table: "StepQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avatars",
                table: "Avatars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserStepQuestions",
                table: "AppUserStepQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserStepQuestions_AspNetUsers_AppUserId",
                table: "AppUserStepQuestions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserStepQuestions_StepQuestions_StepQuestionId",
                table: "AppUserStepQuestions",
                column: "StepQuestionId",
                principalTable: "StepQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Avatars_AvatarId",
                table: "AspNetUsers",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Languages_LanguageId",
                table: "Questions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_StepQuestions_StepQuestionId",
                table: "Questions",
                column: "StepQuestionId",
                principalTable: "StepQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Languages_LanguageId",
                table: "Subjects",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStreaks_AspNetUsers_UserId",
                table: "UserStreaks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
