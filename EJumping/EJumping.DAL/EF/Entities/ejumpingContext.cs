using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EJumping.DAL.EF.Entities
{
    public partial class ejumpingContext : DbContext
    {
        public ejumpingContext()
        {
        }

        public ejumpingContext(DbContextOptions<ejumpingContext> options) : base(options)
        {
        }

        public virtual DbSet<EmailVerification> EmailVerification { get; set; }
        public virtual DbSet<FxCandlestickRound> FxCandlestickRound { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }
        public virtual DbSet<NewsCommentReport> NewsCommentReport { get; set; }
        public virtual DbSet<NewsLike> NewsLike { get; set; }
        public virtual DbSet<PbGamebetWs> PbGamebetWs { get; set; }
        public virtual DbSet<PbGameroundWs> PbGameroundWs { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Roleclaim> Roleclaim { get; set; }
        public virtual DbSet<UserBlock> UserBlock { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserExpLog> UserExpLog { get; set; }
        public virtual DbSet<UserFriend> UserFriend { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserLoginLog> UserLoginLog { get; set; }
        public virtual DbSet<UserMessage> UserMessage { get; set; }
        public virtual DbSet<UserPointLog> UserPointLog { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("host=localhost;database=ejumping;Username=postgres;Password=1qaz!QAZ;");
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ejumping;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<byte[], long>(
                     v => BitConverter.ToInt64(v, 0),
                     v => BitConverter.GetBytes(v));

            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Name = "Ielts",

                },
                new Quiz
                {
                    Id = 2,
                    Name = "Toeic"
                }
                );

            modelBuilder.Entity<Question>()
                .UseXminAsConcurrencyToken();

            modelBuilder.Entity<Question>()
                .HasData(
                new Question
                {
                    Id = 1,
                    QuizId = 1,
                    QuestionName = "Could you tell me your surname?",
                    FirstOption = "Would you like me to spell it?",
                    SecondOption = "Do you like my family name?",
                    ThirdOption = "How do I say that?",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = 2,
                    QuizId = 1,
                    QuestionName = "This plant looks dead.",
                    FirstOption = "It's in the garden.",
                    SecondOption = "It only needs some water.",
                    ThirdOption = "It's sleeping.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = 3,
                    QuizId = 1,
                    QuestionName = "I hope it doesn't rain.",
                    FirstOption = "Of course not.",
                    SecondOption = "Will it be wet?",
                    ThirdOption = "So do I.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = 4,
                    QuizId = 1,
                    QuestionName = "Are you going to come inside soon?",
                    FirstOption = "For ever.",
                    SecondOption = "Not long.",
                    ThirdOption = "In a minute.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = 5,
                    QuizId = 1,
                    QuestionName = "Who gave you this book, Lucy?",
                    FirstOption = "I bought it.",
                    SecondOption = "For my birthday.",
                    ThirdOption = "My uncle was.",
                    CorrectAnswer = 1,

                }, new Question
                {
                    Id = 6,
                    QuizId = 1,
                    QuestionName = "Shall we go out for pizza tonight?",
                    FirstOption = "I know that.",
                    SecondOption = "It's very good.",
                    ThirdOption = "I'm too tired.",
                    CorrectAnswer = 1
                }, new Question
                {
                    Id = 7,
                    QuizId = 1,
                    QuestionName = "Do you mind if I come too?",
                    FirstOption = "That's fine!",
                    SecondOption = "I'd like to.",
                    ThirdOption = "I don't know if I can.",
                    CorrectAnswer = 1,
                }, new Question
                {
                    Id = 8,
                    QuizId = 1,
                    QuestionName = "There's someone at the door.",
                    FirstOption = "Can I help you?",
                    SecondOption = "Well, go and answer it then.",
                    ThirdOption = "He's busy at the moment.",
                    CorrectAnswer = 1,
                }, new Question
                {
                    Id = 9,
                    QuizId = 1,
                    QuestionName = "How much butter do I need for this cake?",
                    FirstOption = "I'd like one.",
                    SecondOption = "I'll use some.",
                    ThirdOption = "I'm not sure.",
                    CorrectAnswer = 1,
                }, new Question
                {
                    Id = 10,
                    QuizId = 1,
                    QuestionName = "How long are you here for?",
                    FirstOption = "Since last week.",
                    SecondOption = "Ten days ago.",
                    ThirdOption = "Till tomorrow.",
                    CorrectAnswer = 1,
                }
                );

            modelBuilder.Entity<EmailVerification>(entity =>
            {
                entity.ToTable("email_verification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Expired).HasColumnName("expired");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasColumnType("character varying");

                entity.Property(e => e.IsSent).HasColumnName("is_sent");

                entity.Property(e => e.LastFailed).HasColumnName("last_failed");

                entity.Property(e => e.NumFailed).HasColumnName("num_failed");

                entity.Property(e => e.RecipientEmail)
                    .HasColumnName("recipient_email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Requested).HasColumnName("requested");

                entity.Property(e => e.VerificationCode)
                    .HasColumnName("verification_code")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<FxCandlestickRound>(entity =>
            {
                entity.ToTable("fx_candlestick_round");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Close)
                    .HasColumnName("close")
                    .HasColumnType("numeric(13,5)");

                entity.Property(e => e.High)
                    .HasColumnName("high")
                    .HasColumnType("numeric(13,5)");

                entity.Property(e => e.Low)
                    .HasColumnName("low")
                    .HasColumnType("numeric(13,5)");

                entity.Property(e => e.Open)
                    .HasColumnName("open")
                    .HasColumnType("numeric(13,5)");

                entity.Property(e => e.RoundDate)
                    .HasColumnName("round_date");

                entity.Property(e => e.RoundNumber).HasColumnName("round_number");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("level");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.MaxExp).HasColumnName("max_exp");

                entity.Property(e => e.MinExp).HasColumnName("min_exp");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<NewsComment>(entity =>
            {
                entity.ToTable("news_comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("character varying");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedById).HasColumnName("deleted_by_id");

                entity.Property(e => e.HiddenAt).HasColumnName("hidden_at");

                entity.Property(e => e.HiddenReason)
                    .HasColumnName("hidden_reason")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastReportedAt).HasColumnName("last_reported_at");

                entity.Property(e => e.NewsId).HasColumnName("news_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NewsComment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_news_comment_user_id");
            });

            modelBuilder.Entity<NewsCommentReport>(entity =>
            {
                entity.ToTable("news_comment_report");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.NewsCommentId).HasColumnName("news_comment_id");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasColumnType("character varying");

                entity.Property(e => e.ReportedById).HasColumnName("reported_by_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.NewsComment)
                    .WithMany(p => p.NewsCommentReport)
                    .HasForeignKey(d => d.NewsCommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("news_comment_report_news_comment_id_fkey");
            });

            modelBuilder.Entity<NewsLike>(entity =>
            {
                entity.ToTable("news_like");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.NewsId).HasColumnName("news_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<PbGamebetWs>(entity =>
            {
                entity.HasKey(e => e.BetId)
                    .HasName("pb_gamebet_ws_pkey");

                entity.ToTable("pb_gamebet_ws");

                entity.Property(e => e.BetId).HasColumnName("bet_id");

                entity.Property(e => e.BetBall).HasColumnName("bet_ball");

                entity.Property(e => e.BetPbOddEven).HasColumnName("bet_pb_odd_even");

                entity.Property(e => e.BetPbPrediction).HasColumnName("bet_pb_prediction");

                entity.Property(e => e.BetPbUnderOver).HasColumnName("bet_pb_under_over");

                entity.Property(e => e.BetRbSumLowHighMedium).HasColumnName("bet_rb_sum_low_high_medium");

                entity.Property(e => e.BetRbSumLowHighMediumOddEven).HasColumnName("bet_rb_sum_low_high_medium_odd_even");

                entity.Property(e => e.BetRbSumOddEven).HasColumnName("bet_rb_sum_odd_even");

                entity.Property(e => e.BetRbSumUnderOver).HasColumnName("bet_rb_sum_under_over");

                entity.Property(e => e.BetRbSumUnderOverOddEven).HasColumnName("bet_rb_sum_under_over_odd_even");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date");

                entity.Property(e => e.GameDate).HasColumnName("game_date");

                entity.Property(e => e.GameRoundId).HasColumnName("game_round_id");

                entity.Property(e => e.HitBall).HasColumnName("hit_ball");

                entity.Property(e => e.HitOdds)
                    .HasColumnName("hit_odds")
                    .HasColumnType("numeric");

                entity.Property(e => e.IsProvide).HasColumnName("is_provide");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("update_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<PbGameroundWs>(entity =>
            {
                entity.HasKey(e => new { e.GameDate, e.GameRoundId })
                    .HasName("pb_gameround_ws_pkey");

                entity.ToTable("pb_gameround_ws");

                entity.Property(e => e.GameDate).HasColumnName("game_date");

                entity.Property(e => e.GameRoundId).HasColumnName("game_round_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date");

                entity.Property(e => e.HitEventId1).HasColumnName("hit_event_id1");

                entity.Property(e => e.HitEventId2).HasColumnName("hit_event_id2");

                entity.Property(e => e.HitEventId3).HasColumnName("hit_event_id3");

                entity.Property(e => e.HitEventId4).HasColumnName("hit_event_id4");

                entity.Property(e => e.HitEventId5).HasColumnName("hit_event_id5");

                entity.Property(e => e.IsProvide).HasColumnName("is_provide");

                entity.Property(e => e.Pb).HasColumnName("pb");

                entity.Property(e => e.PbEventBetCount).HasColumnName("pb_event_bet_count");

                entity.Property(e => e.PbOddBetCount).HasColumnName("pb_odd_bet_count");

                entity.Property(e => e.PbOverBetCount).HasColumnName("pb_over_bet_count");

                entity.Property(e => e.PbUnderBetCount).HasColumnName("pb_under_bet_count");

                entity.Property(e => e.Rb1).HasColumnName("rb1");

                entity.Property(e => e.Rb2).HasColumnName("rb2");

                entity.Property(e => e.Rb3).HasColumnName("rb3");

                entity.Property(e => e.Rb4).HasColumnName("rb4");

                entity.Property(e => e.Rb5).HasColumnName("rb5");

                entity.Property(e => e.RbSumEventBetCount).HasColumnName("rb_sum_event_bet_count");

                entity.Property(e => e.RbSumHighBetCount).HasColumnName("rb_sum_high_bet_count");

                entity.Property(e => e.RbSumLowBetCount).HasColumnName("rb_sum_low_bet_count");

                entity.Property(e => e.RbSumMediumBetCount).HasColumnName("rb_sum_medium_bet_count");

                entity.Property(e => e.RbSumOddBetCount).HasColumnName("rb_sum_odd_bet_count");

                entity.Property(e => e.RbSumOverBetCount).HasColumnName("rb_sum_over_bet_count");

                entity.Property(e => e.RbSumUnderBetCount).HasColumnName("rb_sum_under_bet_count");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnName("concurrency_stamp")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.NormalizedName)
                    .HasColumnName("normalized_name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Roleclaim>(entity =>
            {
                entity.ToTable("roleclaim");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimType)
                    .HasColumnName("claim_type")
                    .HasColumnType("character varying");

                entity.Property(e => e.ClaimValue)
                    .HasColumnName("claim_value")
                    .HasColumnType("character varying");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Roleclaim)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("roleclaim_role_id_fkey");
            });

            modelBuilder.Entity<UserBlock>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BlockedUserId })
                    .HasName("user_block_pkey");

                entity.ToTable("user_block");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BlockedUserId).HasColumnName("blocked_user_id");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.HasOne(d => d.BlockedUser)
                    .WithMany(p => p.UserBlockBlockedUser)
                    .HasForeignKey(d => d.BlockedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_block_blocked_user_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBlockUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_block_user_id_fkey");
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.ToTable("user_claim");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimType)
                    .HasColumnName("claim_type")
                    .HasColumnType("character varying");

                entity.Property(e => e.ClaimValue)
                    .HasColumnName("claim_value")
                    .HasColumnType("character varying");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaim)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_claim_user_id_fkey");
            });

            modelBuilder.Entity<UserExpLog>(entity =>
            {
                entity.ToTable("user_exp_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionType).HasColumnName("action_type");

                entity.Property(e => e.AfterValue).HasColumnName("after_value");

                entity.Property(e => e.BeforeValue).HasColumnName("before_value");

                entity.Property(e => e.ChangeValue).HasColumnName("change_value");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExpLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_exp_log_user_id_fkey");
            });

            modelBuilder.Entity<UserFriend>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FriendId })
                    .HasName("user_friend_pkey");

                entity.ToTable("user_friend");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FriendId).HasColumnName("friend_id");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.FriendSince).HasColumnName("friend_since");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.UserFriendFriend)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_friend_friend_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFriendUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_friend_user_id_fkey");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("user_login_pkey");

                entity.ToTable("user_login");

                entity.Property(e => e.LoginProvider)
                    .HasColumnName("login_provider")
                    .HasColumnType("character varying");

                entity.Property(e => e.ProviderKey)
                    .HasColumnName("provider_key")
                    .HasColumnType("character varying");

                entity.Property(e => e.ProviderDisplayname)
                    .HasColumnName("provider_displayname")
                    .HasColumnType("character varying");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_login_user_id_fkey");
            });

            modelBuilder.Entity<UserLoginLog>(entity =>
            {
                entity.ToTable("user_login_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LoginDate)
                    .HasColumnName("login_date")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.RequestIp)
                    .HasColumnName("request_ip")
                    .HasColumnType("character varying");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasColumnType("character varying");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLoginLog)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_login_log_user_id_fkey");
            });

            modelBuilder.Entity<UserMessage>(entity =>
            {
                entity.ToTable("user_message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("character varying");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.UserMessageReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_message_receiver_id_fkey");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.UserMessageSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_message_sender_id_fkey");
            });

            modelBuilder.Entity<UserPointLog>(entity =>
            {
                entity.ToTable("user_point_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionType).HasColumnName("action_type");

                entity.Property(e => e.AfterValue).HasColumnName("after_value");

                entity.Property(e => e.BeforeValue).HasColumnName("before_value");

                entity.Property(e => e.ChangeType).HasColumnName("change_type");

                entity.Property(e => e.ChangeValue).HasColumnName("change_value");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPointLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_point_log_user_id_fkey");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("user_role_pkey");

                entity.ToTable("user_role");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_role_role_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_role_user_id_fkey");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_token_pkey");

                entity.ToTable("user_token");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LoginProvider)
                    .HasColumnName("login_provider")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserToken)
                    .HasForeignKey<UserToken>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_token_user_id_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessFailedCount).HasColumnName("access_failed_count");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnName("concurrency_stamp")
                    .HasColumnType("character varying");

                entity.Property(e => e.Created)
                    .HasColumnName("created");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");

                entity.Property(e => e.EmailMarketing).HasColumnName("email_marketing");

                entity.Property(e => e.EmailServiceNotification).HasColumnName("email_service_notification");


                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastFriendrequestsRead).HasColumnName("last_friendrequests_read");

                entity.Property(e => e.LastMessagesRead).HasColumnName("last_messages_read");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Locked)
                    .HasColumnName("locked");

                entity.Property(e => e.LockoutEnabled).HasColumnName("lockout_enabled");

                entity.Property(e => e.LockoutEnd).HasColumnName("lockout_end");

                entity.Property(e => e.MfaSecret).HasColumnName("mfa_secret");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnName("normalized_email")
                    .HasColumnType("character varying");

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnName("normalized_user_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasColumnType("character varying");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");

                entity.Property(e => e.PreferredLanguage)
                    .HasColumnName("preferred_language")
                    .HasColumnType("character varying");

                entity.Property(e => e.ProfileImageUrl)
                    .HasColumnName("profile_image_url")
                    .HasColumnType("character varying");

                entity.Property(e => e.SecurityStamp)
                    .HasColumnName("security_stamp")
                    .HasColumnType("character varying");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("two_factor_enabled");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.VerificationStatus).HasColumnName("verification_status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
