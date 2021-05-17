using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EJumping.DAL.Migrations.AdsDb
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "email_verification",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    recipient_email = table.Column<string>(type: "character varying", nullable: true),
                    is_sent = table.Column<bool>(type: "bit", nullable: true),
                    verification_code = table.Column<string>(type: "character varying", nullable: true),
                    requested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_failed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    num_failed = table.Column<int>(type: "int", nullable: true),
                    ip_address = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_verification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fx_candlestick_round",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timestamp = table.Column<long>(type: "bigint", nullable: false),
                    round_number = table.Column<int>(type: "int", nullable: false),
                    open = table.Column<decimal>(type: "numeric(13,5)", nullable: false),
                    close = table.Column<decimal>(type: "numeric(13,5)", nullable: false),
                    low = table.Column<decimal>(type: "numeric(13,5)", nullable: false),
                    high = table.Column<decimal>(type: "numeric(13,5)", nullable: false),
                    round_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fx_candlestick_round", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "level",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "character varying", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    min_exp = table.Column<int>(type: "int", nullable: true),
                    max_exp = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_like",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    news_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_like", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pb_gamebet_ws",
                columns: table => new
                {
                    bet_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    game_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    bet_ball = table.Column<long>(type: "bigint", nullable: false),
                    hit_odds = table.Column<decimal>(type: "numeric", nullable: false),
                    hit_ball = table.Column<long>(type: "bigint", nullable: false),
                    is_provide = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    game_round_id = table.Column<long>(type: "bigint", nullable: false),
                    bet_pb_odd_even = table.Column<int>(type: "int", nullable: false),
                    bet_pb_prediction = table.Column<int>(type: "int", nullable: false),
                    bet_pb_under_over = table.Column<int>(type: "int", nullable: false),
                    bet_rb_sum_low_high_medium = table.Column<int>(type: "int", nullable: false),
                    bet_rb_sum_low_high_medium_odd_even = table.Column<int>(type: "int", nullable: false),
                    bet_rb_sum_odd_even = table.Column<int>(type: "int", nullable: false),
                    bet_rb_sum_under_over = table.Column<int>(type: "int", nullable: false),
                    bet_rb_sum_under_over_odd_even = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pb_gamebet_ws_pkey", x => x.bet_id);
                });

            migrationBuilder.CreateTable(
                name: "pb_gameround_ws",
                columns: table => new
                {
                    game_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    game_round_id = table.Column<long>(type: "bigint", nullable: false),
                    rb1 = table.Column<int>(type: "int", nullable: true),
                    rb2 = table.Column<int>(type: "int", nullable: true),
                    rb3 = table.Column<int>(type: "int", nullable: true),
                    rb4 = table.Column<int>(type: "int", nullable: true),
                    rb5 = table.Column<int>(type: "int", nullable: true),
                    pb = table.Column<int>(type: "int", nullable: true),
                    rb_sum_odd_bet_count = table.Column<int>(type: "int", nullable: false),
                    rb_sum_event_bet_count = table.Column<int>(type: "int", nullable: false),
                    rb_sum_under_bet_count = table.Column<int>(type: "int", nullable: false),
                    rb_sum_over_bet_count = table.Column<int>(type: "int", nullable: false),
                    pb_odd_bet_count = table.Column<int>(type: "int", nullable: false),
                    pb_event_bet_count = table.Column<int>(type: "int", nullable: false),
                    pb_under_bet_count = table.Column<int>(type: "int", nullable: false),
                    pb_over_bet_count = table.Column<int>(type: "int", nullable: false),
                    rb_sum_low_bet_count = table.Column<int>(type: "int", nullable: false),
                    rb_sum_high_bet_count = table.Column<int>(type: "int", nullable: false),
                    rb_sum_medium_bet_count = table.Column<int>(type: "int", nullable: false),
                    hit_event_id1 = table.Column<int>(type: "int", nullable: false),
                    hit_event_id2 = table.Column<int>(type: "int", nullable: false),
                    hit_event_id3 = table.Column<int>(type: "int", nullable: false),
                    hit_event_id4 = table.Column<int>(type: "int", nullable: false),
                    hit_event_id5 = table.Column<int>(type: "int", nullable: false),
                    is_provide = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pb_gameround_ws_pkey", x => new { x.game_date, x.game_round_id });
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    normalized_name = table.Column<string>(type: "character varying", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "character varying", nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying", nullable: true),
                    email = table.Column<string>(type: "character varying", nullable: true),
                    normalized_email = table.Column<string>(type: "character varying", nullable: true),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    first_name = table.Column<string>(type: "character varying", nullable: true),
                    last_name = table.Column<string>(type: "character varying", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    gender = table.Column<int>(type: "int", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    profile_image_url = table.Column<string>(type: "character varying", nullable: true),
                    preferred_language = table.Column<string>(type: "character varying", nullable: true),
                    password_hash = table.Column<string>(type: "character varying", nullable: true),
                    security_stamp = table.Column<string>(type: "character varying", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "character varying", nullable: true),
                    two_factor_enabled = table.Column<bool>(type: "bit", nullable: false),
                    lockout_enabled = table.Column<bool>(type: "bit", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false),
                    mfa_secret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locked = table.Column<bool>(type: "bit", nullable: true),
                    lockout_end = table.Column<DateTime>(type: "datetime2", nullable: true),
                    email_marketing = table.Column<bool>(type: "bit", nullable: true),
                    email_service_notification = table.Column<bool>(type: "bit", nullable: true),
                    level = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    verification_status = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_messages_read = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_friendrequests_read = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswer = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswerPoints = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roleclaim",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<long>(type: "bigint", nullable: true),
                    claim_type = table.Column<string>(type: "character varying", nullable: true),
                    claim_value = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleclaim", x => x.id);
                    table.ForeignKey(
                        name: "roleclaim_role_id_fkey",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "news_comment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    news_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    last_reported_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hidden_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    content = table.Column<string>(type: "character varying", nullable: false),
                    hidden_reason = table.Column<string>(type: "character varying", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_comment", x => x.id);
                    table.ForeignKey(
                        name: "users_news_comment_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_block",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    blocked_user_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_block_pkey", x => new { x.user_id, x.blocked_user_id });
                    table.ForeignKey(
                        name: "user_block_blocked_user_id_fkey",
                        column: x => x.blocked_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_block_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_claim",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    claim_type = table.Column<string>(type: "character varying", nullable: true),
                    claim_value = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "user_claim_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_exp_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    action_type = table.Column<int>(type: "int", nullable: false),
                    before_value = table.Column<long>(type: "bigint", nullable: false),
                    change_value = table.Column<long>(type: "bigint", nullable: false),
                    after_value = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_exp_log", x => x.id);
                    table.ForeignKey(
                        name: "user_exp_log_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_friend",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    friend_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    friend_since = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_friend_pkey", x => new { x.user_id, x.friend_id });
                    table.ForeignKey(
                        name: "user_friend_friend_id_fkey",
                        column: x => x.friend_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_friend_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_login",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "character varying", nullable: false),
                    provider_key = table.Column<string>(type: "character varying", nullable: false),
                    provider_displayname = table.Column<string>(type: "character varying", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_login_pkey", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "user_login_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_login_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    request_ip = table.Column<string>(type: "character varying", nullable: true),
                    user_agent = table.Column<string>(type: "character varying", nullable: true),
                    login_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login_log", x => x.id);
                    table.ForeignKey(
                        name: "user_login_log_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sender_id = table.Column<long>(type: "bigint", nullable: false),
                    receiver_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    content = table.Column<string>(type: "character varying", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_message", x => x.id);
                    table.ForeignKey(
                        name: "user_message_receiver_id_fkey",
                        column: x => x.receiver_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_message_sender_id_fkey",
                        column: x => x.sender_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_point_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    action_type = table.Column<int>(type: "int", nullable: false),
                    change_type = table.Column<int>(type: "int", nullable: false),
                    before_value = table.Column<long>(type: "bigint", nullable: false),
                    change_value = table.Column<long>(type: "bigint", nullable: false),
                    after_value = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_point_log", x => x.id);
                    table.ForeignKey(
                        name: "user_point_log_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_role_pkey", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "user_role_role_id_fkey",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_role_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    login_provider = table.Column<string>(type: "character varying", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    value = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_token_pkey", x => x.user_id);
                    table.ForeignKey(
                        name: "user_token_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "news_comment_report",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    news_comment_id = table.Column<long>(type: "bigint", nullable: false),
                    reason = table.Column<string>(type: "character varying", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reported_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_comment_report", x => x.id);
                    table.ForeignKey(
                        name: "news_comment_report_news_comment_id_fkey",
                        column: x => x.news_comment_id,
                        principalTable: "news_comment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "QuizLogoUrl" },
                values: new object[] { 1, "Ielts", null });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "QuizLogoUrl" },
                values: new object[] { 2, "Toeic", null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "CorrectAnswerPoints", "FirstOption", "FourthOption", "QuestionName", "QuizId", "SecondOption", "ThirdOption" },
                values: new object[,]
                {
                    { 1, 1, 0, "Would you like me to spell it?", null, "Could you tell me your surname?", 1, "Do you like my family name?", "How do I say that?" },
                    { 2, 1, 0, "It's in the garden.", null, "This plant looks dead.", 1, "It only needs some water.", "It's sleeping." },
                    { 3, 1, 0, "Of course not.", null, "I hope it doesn't rain.", 1, "Will it be wet?", "So do I." },
                    { 4, 1, 0, "For ever.", null, "Are you going to come inside soon?", 1, "Not long.", "In a minute." },
                    { 5, 1, 0, "I bought it.", null, "Who gave you this book, Lucy?", 1, "For my birthday.", "My uncle was." },
                    { 6, 1, 0, "I know that.", null, "Shall we go out for pizza tonight?", 1, "It's very good.", "I'm too tired." },
                    { 7, 1, 0, "That's fine!", null, "Do you mind if I come too?", 1, "I'd like to.", "I don't know if I can." },
                    { 8, 1, 0, "Can I help you?", null, "There's someone at the door.", 1, "Well, go and answer it then.", "He's busy at the moment." },
                    { 9, 1, 0, "I'd like one.", null, "How much butter do I need for this cake?", 1, "I'll use some.", "I'm not sure." },
                    { 10, 1, 0, "Since last week.", null, "How long are you here for?", 1, "Ten days ago.", "Till tomorrow." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_comment_user_id",
                table: "news_comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_news_comment_report_news_comment_id",
                table: "news_comment_report",
                column: "news_comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_roleclaim_role_id",
                table: "roleclaim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_block_blocked_user_id",
                table: "user_block",
                column: "blocked_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_claim_user_id",
                table: "user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_exp_log_user_id",
                table: "user_exp_log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_friend_friend_id",
                table: "user_friend",
                column: "friend_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_login_user_id",
                table: "user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_login_log_user_id",
                table: "user_login_log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_message_receiver_id",
                table: "user_message",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_message_sender_id",
                table: "user_message",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_point_log_user_id",
                table: "user_point_log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_role_id",
                table: "user_role",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email_verification");

            migrationBuilder.DropTable(
                name: "fx_candlestick_round");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "news_comment_report");

            migrationBuilder.DropTable(
                name: "news_like");

            migrationBuilder.DropTable(
                name: "pb_gamebet_ws");

            migrationBuilder.DropTable(
                name: "pb_gameround_ws");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "roleclaim");

            migrationBuilder.DropTable(
                name: "user_block");

            migrationBuilder.DropTable(
                name: "user_claim");

            migrationBuilder.DropTable(
                name: "user_exp_log");

            migrationBuilder.DropTable(
                name: "user_friend");

            migrationBuilder.DropTable(
                name: "user_login");

            migrationBuilder.DropTable(
                name: "user_login_log");

            migrationBuilder.DropTable(
                name: "user_message");

            migrationBuilder.DropTable(
                name: "user_point_log");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "news_comment");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
