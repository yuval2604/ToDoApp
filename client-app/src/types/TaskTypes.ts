export enum TASK_STATUSES {
  NOT_DONE = 0,
  DONE = 1,
}

export interface Task {
  id?: string;
  content: string;
  status?: keyof typeof TASK_STATUSES;
}
