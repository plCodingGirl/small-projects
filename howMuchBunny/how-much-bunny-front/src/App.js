import React from 'react';
import './App.css';

function Todo({ todo }) {
  return (
      <div className="todo">
        {todo.text}
      </div>
  );
};

function App() {
  const [todos, setTodos] = React.useState([
    { text: "Nikonek" },
    { text: "Amelionek" },
    { text: "Helenkonek" }
  ]);

  return (
      <div className="app">
        <div className="todo-list">
          {todos.map((todo, index) => (
              <Todo
                  key={index}
                  index={index}
                  todo={todo}
              />
          ))}
        </div>
      </div>
  );
}

export default App;