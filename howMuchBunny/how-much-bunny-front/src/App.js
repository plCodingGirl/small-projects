import React from 'react';
import './App.css';

function TodoForm({ addTodo }) {
    const [value, setValue] = React.useState("");

    const handleSubmit = e => {
        e.preventDefault();
        if (!value) return;
        addTodo(value);
        setValue("");
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                className="input"
                value={value}
                onChange={e => setValue(e.target.value)}
            />
        </form>
    );
}
function Todo({ todo, index, completeTodo }) {
  return (
      <div className="todo"
          style={{ textDecoration: todo.isCompleted ? "line-through" : "" }}
          >
          {todo.text}
          <div>
              <button onClick={() => completeTodo(index)}>Complete</button>
          </div>
      </div>
  );
};

function App() {
  const [todos, setTodos] = React.useState([
    { text: "Nikonek",
        isCompleted: false
    },
    { text: "Amelionek",
        isCompleted: false
    },
    { text: "Helenkonek",
        isCompleted: false
    }
  ]);
    const addTodo = text => {
        const newTodos = [...todos, { text }];
        setTodos(newTodos);
    };

    const completeTodo = index => {
        const newTodos = [...todos];
        newTodos[index].isCompleted = true;
        setTodos(newTodos);
    };

  return (
      <div className="app">
        <div className="todo-list">
          {todos.map((todo, index) => (
              <Todo
                  key={index}
                  index={index}
                  todo={todo}
                  completeTodo={completeTodo}
              />
          ))}
            <TodoForm addTodo={addTodo} />
        </div>
      </div>
  );
}

export default App;