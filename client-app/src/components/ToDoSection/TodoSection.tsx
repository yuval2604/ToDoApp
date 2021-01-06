import React, { useMemo } from "react";
import "./TodoSection.css";
import TaskCard from "../TaskCard/TaskCard";
import AddIcon from "@material-ui/icons/Add";
import { SectionProps } from "../../types/SectionTypes";
import Task from "../../models/Task";
import { TASK_STATUSES } from "../../types/TaskTypes";
import axios from "axios";
import shortid from "shortid";

function TodoSection(props: SectionProps) {
  const { tasks, setTasks } = props;

  //   const addTask = async () => {
  //     try {
  //       const task = {"content"}
  //       const resp = await axios.post("http://localhost:5001/api/v1/tasks", task);

  //       setTasks([...tasks, task]);
  //     } catch (err) {
  //       // @TODO: UI error handling
  //       console.log(err);
  //     }
  //   };

  const todoCards = useMemo(() => {
    const todoTasks = tasks.filter((task) => task.status == "NOT_DONE");
    const todoCards = todoTasks.map((task) => (
      <TaskCard key={task.id} {...props} task={task} />
    ));
    return todoCards;
  }, [tasks, props]);

  return (
    <div className="categoryContainer">
      <h1>To-Do</h1>
      {todoCards}
      <AddIcon id="addCardIcon" onClick={() => {}} />
    </div>
  );
}

export default TodoSection;
