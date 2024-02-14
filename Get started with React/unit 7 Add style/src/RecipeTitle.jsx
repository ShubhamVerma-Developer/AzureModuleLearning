import React from "react";
import "./index.css";

function RecipeTitle() {
  const title = "Mashed potatoes";
  return (
    <h2>
      {title} {Date.now()}
    </h2>
  );
}
export default RecipeTitle;
