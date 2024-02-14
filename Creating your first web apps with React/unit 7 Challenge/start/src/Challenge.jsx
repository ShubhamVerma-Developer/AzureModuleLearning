import "./IngredientList.css";
import React from "react";

function Challenge(props) {
  const list = props.list;
  console.log(props.list);
  return list.map((list, i) => (
    <li>
      {i + 1} {list}
    </li>
  ));
}

export default Challenge;
