import React, { useMemo } from "react";
import "./DoneSection.css";
import { SectionProps } from "../../types/SectionTypes";
import { TASK_STATUSES } from "../../types/TaskTypes";
import TaskCard from "../TaskCard/TaskCard";

function DoneSection(props: SectionProps) {
  const { tasks } = props;

  const doneCards = useMemo(() => {
    const doneTasks = tasks.filter((task) => task.status === "DONE");

    const doneCards = doneTasks.map((task) => (
      <TaskCard {...props} task={task} />
    ));
    return doneCards;
  }, [tasks, props]);

  return (
    <div className="categoryContainer">
      <h1>Done2</h1>
      {doneCards}
    </div>
  );
}

export default DoneSection;
