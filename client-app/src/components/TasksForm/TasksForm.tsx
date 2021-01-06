import React, { useState } from "react";
import { Task } from "../../interfaces/interfaces";
import { createTask } from "../../services/tasks";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  TextField,
  DialogActions,
  Button,
} from "@material-ui/core";
import "./TasksForm.scss";

interface Props {
  isOpened: boolean;
  setIsOpened: (isOpened: boolean) => void;
  setTasks: (tasks: any) => void;
  setError: (error: string) => void;
}

const TasksForm: React.FC<Props> = ({
  isOpened,
  setIsOpened,
  setTasks,
  setError,
}) => {
  const [taskValues, setTaskValues] = useState({
    content: "",
  });

  const addTask = async () => {
    const { content } = taskValues;

    if (content) {
      const res = await createTask(content);

      if (res.success) {
        const { id } = res.data;
        const newTask = { ...taskValues, id, status: 0 };
        setTasks((prevTasks: Task[]) => [...prevTasks, newTask]);
      }

      closeForm();
    } else {
      setError("Please fill out form correctly");
    }
  };

  const closeForm = () => {
    setTaskValues({ content: "" });
    setIsOpened(false);
  };

  return (
    <Dialog
      className="tasks-form"
      open={isOpened}
      onClose={closeForm}
      aria-labelledby="form-dialog-title"
    >
      <DialogTitle className="title">Add Task</DialogTitle>
      <DialogContent>
        <TextField
          autoFocus
          margin="dense"
          label="content"
          fullWidth
          onChange={(e) =>
            setTaskValues({ ...taskValues, content: e.target.value })
          }
        />
      </DialogContent>
      <DialogActions className="actions">
        <Button onClick={addTask}>Save</Button>
        <Button onClick={closeForm}>Cancel</Button>
      </DialogActions>
    </Dialog>
  );
};

export default TasksForm;
