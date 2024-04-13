import { useState } from "react";
import "./App.css";
import { Component } from "react";

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      notes: [],
    };
  }

  API_URL = "https://localhost:7156/";

  componentDidMount() {
    this.refreshNotes();
  }
  async refreshNotes() {
    fetch(this.API_URL + "api/Todo/GetNotes")
      .then((response) => response.json())
      .then((data) => {
        this.setState({ notes: data });
        console.log(data);
      });
  }

  async addClick() {
    var newNotes = document.getElementById("newNotes").value;
    console.log(newNotes);
    const data = new FormData();
    data.append("newNotes", newNotes);

    fetch(this.API_URL + "api/Todo/AddNotes", { method: "POST", body: data })
      .then((res) => res.json())
      .then((result) => {
        alert(result);
        this.refreshNotes();
      });
  }

  async deleteClick(id) {
    const data = new FormData();
    data.append("id", id);

    fetch(this.API_URL + "api/Todo/DeleteNote", {
      method: "DELETE",
      body: data,
    })
      .then((res) => res.json())
      .then((result) => {
        alert(result);
        this.refreshNotes();
      });
  }

  render() {
    const { notes } = this.state;
    console.log(notes);
    return (
      <div className="App">
        <h2>Todo App</h2>
        <input id="newNotes" />
        &nbsp;
        <button onClick={() => this.addClick()}>Add Note</button>
        {notes.map((note) => (
          <p key={note.id}>
            <b>* {note.id}</b>
            <b>* {note.description}</b>
            {"          "}
            <button
              onClick={() => this.deleteClick(note.id)}
              style={{ border: "2px solid red" }}
            >
              delete
            </button>
          </p>
        ))}
      </div>
    );
  }
}

export default App;
