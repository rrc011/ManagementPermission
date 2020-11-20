import { TypeOfPermissionDto } from "./TypeOfPermissionDto";

export interface PermissionDto {
  name?: string;
  lastName?: string;
  type?: number;
  typeOfPermissionId?: number;
  typeOfPermission?: TypeOfPermissionDto;
  id?: number;
  created?: Date;
}
