import { Role } from "./Role";

export type UserProfileToken = {
    userName:string;
    email: string;
    token:string;
    roles: Role[];
}

export type UserProfile = {
    userName:string;
    email:string;
}