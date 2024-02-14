import React from "react";
import "./RecipeTitle.css";
// TODO: Create RecipeTitle component
// TODO: Create RecipeTitle component
function RecipeTitle(props) {
  return (
    <section>
      <h3 className={props.feedback.rating <= 3.5 ? "red" : "green"}>
        {props.feedback.rating} from {props.feedback.reviews} reviews
      </h3>
    </section>
  );
}

export default RecipeTitle;
