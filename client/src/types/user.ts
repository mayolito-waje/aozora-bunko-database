export interface User {
  id: string;
  email: string;
  username: string;
  profilePictureUrl?: string;
  token: string;
}

export interface UserLogin {
  email: string;
  password: string;
}
