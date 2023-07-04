using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data.Services
{
    public interface IFoodData
    {
        int addFoodHistory(DateTime journalDate, int servingSize, int userId, int foodId);

        int addRecipe(DateTime journalDate, int servingSize, int userId, int recipeId);

        int addRecipeDb(string recipeName, int servingSize, int foodId, int userId);

    }
}
