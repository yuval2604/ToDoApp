import { TASK_STATUSES } from "../types/TaskTypes";
import axios from "axios";

export default class Task {
  id: string | null;
  status?: keyof typeof TASK_STATUSES;
  content: string;

  constructor(
    status: keyof typeof TASK_STATUSES,
    content: string,
    id?: string
  ) {
    this.id = id ? id : null;
    this.status = status;
    this.content = content;
  }
  async create() {
    try {
      await axios.post("http://localhost:5001/api/v1/tasks", {
        data: { id: this.id },
      });
    } catch (err) {
      throw err;
    }
  }

  async update() {
    try {
      await axios.put(`http://localhost:5001/api/v1/tasks/${this.id}`);
    } catch (err) {
      throw err;
    }
  }

  async Undone() {
    try {
      await axios.put(`http://localhost:5001/api/v1/tasks/${this.id}`);
    } catch (err) {
      throw err;
    }
  }

  async delete() {
    try {
      await axios.delete(`http://localhost:5001/api/v1/tasks/${this.id}`);
    } catch (err) {
      throw err;
    }
  }
}
