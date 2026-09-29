export interface Garden {
  id: string;
  name: string;
  widthCm: number;
  lengthCm: number;
  createdAt: string;
}

export interface CreateGardenRequest {
  name: string;
  widthCm: number;
  lengthCm: number;
}
