import http from "../http-common";

class TypeOfPermissionsService {
  getAll() {
    return http.get("/TypeOfPermission");
  }

  get(id: number) {
    return http.get(`/TypeOfPermission/${id}`);
  }

  create(data: any) {
    return http.post("/TypeOfPermission", data);
  }

  update(id: number, data: any) {
    return http.put(`/TypeOfPermission/${id}`, data);
  }

  delete(id: number) {
    return http.delete(`/TypeOfPermission/${id}`);
  }
}

export default new TypeOfPermissionsService();
