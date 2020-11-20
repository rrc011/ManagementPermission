import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:52405/api",
  headers: {
    "Content-type": "application/json",
  },
});
