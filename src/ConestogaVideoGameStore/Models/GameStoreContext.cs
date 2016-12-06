using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConestogaVideoGameStore.Models
{
    public partial class GameStoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=gameDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendsList>(entity =>
            {
                entity.ToTable("friendsList");

                entity.HasIndex(e => e.FriendId)
                    .HasName("UQ__friendsL__6A5D6716BC607BAF")
                    .IsUnique();

                entity.HasIndex(e => e.MemberId)
                    .HasName("UQ__friendsL__7FD7CF1715E63390")
                    .IsUnique();

                entity.Property(e => e.FriendsListId)
                    .HasColumnName("friendsListId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FriendId).HasColumnName("friendId");

                entity.Property(e => e.MemberId).HasColumnName("memberId");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__game__72E12F1B95C969AE")
                    .IsUnique();

                entity.HasIndex(e => e.SalesDiscountId)
                    .HasName("UQ__game__4C48BC3CDB19D02A")
                    .IsUnique();

                entity.Property(e => e.GameId)
                    .HasColumnName("gameId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Esrb).HasColumnName("ESRB");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SalesDiscountId).HasColumnName("salesDiscountId");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.HasIndex(e => e.DisplayName)
                    .HasName("UQ__member__32DE959A2501C0B1")
                    .IsUnique();

                entity.HasIndex(e => e.FriendListId)
                    .HasName("UQ__member__2C716EAC3F4177B9")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentId)
                    .HasName("UQ__member__A0D9EFC707167DAD")
                    .IsUnique();

                entity.HasIndex(e => e.WishlistId)
                    .HasName("UQ__member__46E2A1B19DE355A2")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("displayName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FriendListId).HasColumnName("friendListId");

                entity.Property(e => e.IsEmployee).HasColumnName("isEmployee");

                entity.Property(e => e.MemberPassword)
                    .IsRequired()
                    .HasColumnName("memberPassword")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.WishlistId).HasColumnName("wishlistId");
            });

            modelBuilder.Entity<MemberDetails>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__memberDe__7FD7CF16BC2284C0");

                entity.ToTable("memberDetails");

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("emailAddress")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FavoriteGenre)
                    .HasColumnName("favoriteGenre")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.FavoritePlatform)
                    .HasColumnName("favoritePlatform")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MailingAddress)
                    .HasColumnName("mailingAddress")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Promotional).HasColumnName("promotional");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnName("shippingAddress")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<MemberEvents>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__memberEv__2DC7BD097EDA7357");

                entity.ToTable("memberEvents");

                entity.HasIndex(e => e.RegisteredMembersId)
                    .HasName("UQ__memberEv__04E721B52B65A152")
                    .IsUnique();

                entity.Property(e => e.EventId)
                    .HasColumnName("eventId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateAndTime)
                    .HasColumnName("dateAndTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EDescription)
                    .IsRequired()
                    .HasColumnName("eDescription")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.RegisteredMembersId).HasColumnName("registeredMembersId");
            });

            modelBuilder.Entity<MemberGameRepository>(entity =>
            {
                entity.HasKey(e => e.LibraryId)
                    .HasName("PK__memberGa__95E69EEE8DA7D61C");

                entity.ToTable("memberGameRepository");

                entity.HasIndex(e => e.GameId)
                    .HasName("UQ__memberGa__DA90B45308044585")
                    .IsUnique();

                entity.HasIndex(e => e.MemberId)
                    .HasName("UQ__memberGa__7FD7CF17BA7EED63")
                    .IsUnique();

                entity.Property(e => e.LibraryId)
                    .HasColumnName("libraryId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnName("dateOfPurchase")
                    .HasColumnType("datetime");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.MemberId).HasColumnName("memberId");
            });

            modelBuilder.Entity<PaymentInformation>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__paymentI__A0D9EFC6D714E80E");

                entity.ToTable("paymentInformation");

                entity.HasIndex(e => e.CardNumber)
                    .HasName("UQ__paymentI__4CD3FAA2E730D826")
                    .IsUnique();

                entity.Property(e => e.PaymentId)
                    .HasColumnName("paymentId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CardNumber).HasColumnName("cardNumber");

                entity.Property(e => e.Csc).HasColumnName("csc");

                entity.Property(e => e.PayType)
                    .IsRequired()
                    .HasColumnName("payType")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__reviews__2ECD6E04104D9558");

                entity.ToTable("reviews");

                entity.HasIndex(e => e.GameId)
                    .HasName("UQ__reviews__DA90B4535D12E79E")
                    .IsUnique();

                entity.HasIndex(e => e.MemberId)
                    .HasName("UQ__reviews__7FD7CF1735BBAFD4")
                    .IsUnique();

                entity.Property(e => e.ReviewId)
                    .HasColumnName("reviewId")
                    .ValueGeneratedNever();

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Review)
                    .HasColumnName("review")
                    .HasColumnType("varchar(1000)");
            });

            modelBuilder.Entity<SalesDiscounts>(entity =>
            {
                entity.HasKey(e => e.SalesDiscountId)
                    .HasName("PK__salesDis__4C48BC3D49AFBC3B");

                entity.ToTable("salesDiscounts");

                entity.HasIndex(e => e.SalesDiscount)
                    .HasName("UQ__salesDis__6C4BB4610CF2D3EB")
                    .IsUnique();

                entity.Property(e => e.SalesDiscountId)
                    .HasColumnName("salesDiscountId")
                    .ValueGeneratedNever();

                entity.Property(e => e.SalesDiscount).HasColumnName("salesDiscount");
            });

            modelBuilder.Entity<SalesHistory>(entity =>
            {
                entity.HasKey(e => e.SalesId)
                    .HasName("PK__salesHis__E31CBA9022E7CF55");

                entity.ToTable("salesHistory");

                entity.HasIndex(e => e.GameId)
                    .HasName("UQ__salesHis__DA90B453627B243F")
                    .IsUnique();

                entity.HasIndex(e => e.MemberId)
                    .HasName("UQ__salesHis__7FD7CF17B052B553")
                    .IsUnique();

                entity.Property(e => e.SalesId)
                    .HasColumnName("salesID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.PriceAtPurchase).HasColumnName("priceAtPurchase");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("wishlist");

                entity.HasIndex(e => e.GameId)
                    .HasName("UQ__wishlist__DA90B4538EB9D706")
                    .IsUnique();

                entity.Property(e => e.WishlistId)
                    .HasColumnName("wishlistId")
                    .ValueGeneratedNever();

                entity.Property(e => e.GameId).HasColumnName("gameId");
            });
        }

        public virtual DbSet<FriendsList> FriendsList { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberDetails> MemberDetails { get; set; }
        public virtual DbSet<MemberEvents> MemberEvents { get; set; }
        public virtual DbSet<MemberGameRepository> MemberGameRepository { get; set; }
        public virtual DbSet<PaymentInformation> PaymentInformation { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SalesDiscounts> SalesDiscounts { get; set; }
        public virtual DbSet<SalesHistory> SalesHistory { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
    }
}