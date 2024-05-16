using SmartSaver_backend.Infrastructure;
using System.Reflection;

namespace SmartSaver_backend.Repositories
{
    public static class RepositoryExtensions
    {
        public static void Map(this User dbUser, User user)
        {
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.PasswordHash = user.PasswordHash;
            dbUser.Email = user.Email;
            dbUser.PhoneNumber = user.PhoneNumber;
            dbUser.ProfileImage = user.ProfileImage;
            dbUser.Kycdoc = user.Kycdoc;
            dbUser.CreatedAt = user.CreatedAt;
            dbUser.UpdatedAt = user.UpdatedAt;
            dbUser.Status = user.Status;

        }

        public static void Map(this Card dbCard, Card card)
        {
            dbCard.CardId = card.CardId;
            dbCard.UserId = card.UserId;
            dbCard.TotalBalance = card.TotalBalance;
            dbCard.SavingBalance = card.SavingBalance;
            dbCard.AvailableBalance = card.AvailableBalance;
            dbCard.CreatedAt = card.CreatedAt;
            dbCard.UpdatedAt = card.UpdatedAt;

        }

    }

}
