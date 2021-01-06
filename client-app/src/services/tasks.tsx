import { Task } from "../interfaces/interfaces";

const url = `http://localhost:5001/api/v1/tasks`;

const getAllTasks = async () => {
  const res = await fetch(url);
  return responseHandler(res);
};

const createTask = async (taskContent: string) => {
  const options = setRestOptions("POST", { taskContent });
  const res = await fetch(url, options);
  return responseHandler(res);
};

const toggleTaskStatus = async (id: string) => {
  const options = setRestOptions("PUT", { id });
  const res = await fetch(`${url}/${id}`, options);
  return responseHandler(res);
};

const deleteTask = async (id: string) => {
  const options = setRestOptions("DELETE", { id });
  const res = await fetch(`${url}/${id}`, options);
  return responseHandler(res);
};

const setRestOptions = (methodType: string, body?: any) => {
  return {
    method: methodType,
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(body),
  };
};

const responseHandler = async (serverRes: Response) => {
  let res: any = { success: false };

  try {
    const data = await serverRes.json();

    if (data) {
      res = { success: true, data };
    }
  } catch (err) {}

  return res;
};

export { getAllTasks, createTask, toggleTaskStatus, deleteTask };
