import React from "react";

function RecipeTitle() {
  const title = "Mashed potatoes";
  return (
    <h2>
      {title} {Date.now()}
    </h2>
  );
}
export default RecipeTitle;
