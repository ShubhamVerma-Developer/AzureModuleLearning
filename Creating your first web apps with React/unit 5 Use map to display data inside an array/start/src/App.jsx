import "./index.css";
import React from "react";
// TODO: Import RecipeTitle
import RecipeTitle from "./RecipeTitle";

// TODO: Import IngredientList

function App() {
  // TODO: Add recipe object
  const recipe = {
    title: "Mashed potatoes",
    feedback: {
      rating: 4.8,
      reviews: 20,
    },
    ingredients: [
      { name: '3 potatoes, cut into 1/2" pieces', prepared: false },
      { name: "4 Tbsp butter", prepared: false },
      { name: "1/8 cup heavy cream", prepared: false },
      { name: "Salt", prepared: true },
      { name: "Pepper", prepared: true },
    ],
  };

  const numbers = [2, 5, 8];

  // const squared = numbers.map((number) => {
  //   return number * number;
  // });

  const squared = numbers.map((number, index) => {
    return <div key={index}>{number * number}</div>;
  });

  console.log(squared);

  console.log(numbers);
  return (
    <article>
      <h1>Recipe Manager</h1>
      {/* TODO: Add RecipeTitle component */}
      <RecipeTitle title={recipe.title} feedback={recipe.feedback} />
      {/* TODO: Add IngredientList component */}
      <h2>{squared}</h2>
    </article>
  );
}

export default App;
