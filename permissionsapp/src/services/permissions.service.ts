import http from "../http-common";

class PermissionsService {
  getAll(pageNumber?: number, pageSize?: number) {
    let url = "/Permission";
    if (pageSize || pageNumber) url += "?";
    if (pageNumber) url += `PageNumber=${pageNumber}`;
    if (pageSize) url += `&PageSize=${pageSize}`;
    return http.get(url);
  }

  get(id: number) {
    return http.get(`/Permission/${id}`);
  }

  create(data: any) {
    return http.post("/Permission", data);
  }

  update(id: number, data: any) {
    return http.put(`/Permission/${id}`, data);
  }

  delete(id: number) {
    return http.delete(`/Permission/${id}`);
  }
}

export default new PermissionsService();
