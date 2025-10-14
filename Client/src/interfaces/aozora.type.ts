// TODO: Use English properties in the backend. Japanese properties creates confusion lol

export interface WrittenWorksAuthor {
  id: string;
  姓: string;
  姓読み: string;
  姓読みソート用: string;
  姓ローマ字: string;
  名: string;
  名読み: string;
  名読みソート用: string;
  名ローマ字: string;
  生年月日: string;
  没年月日: string;
  人物著作権フラグ: boolean;
}

export interface Source {
  id: string;
  底本名: string;
  底本出版社ID?: string;
  底本出版社名?: string;
  底本出版社発行年?: string;
  底本の親元ID?: string;
  底本の親元名?: string;
  底本の親本出版社ID?: string;
  底本の親本出版社名?: string;
  底本の親本出版社発行年?: string;
}

export interface WrittenWorks {
  id: string;
  作品名: string;
  作品名読み: string;
  ソート用読み: string;
  副題: string;
  副題読み: string;
  原題: string;
  初出: string;
  文字使い種別: string;
  作品著作権フラグ: boolean;
  人物: WrittenWorksAuthor;
  役割フラグ: string;
  底本?: Source;
  底本2?: Source;
  テキストファイルURL: string;
  "xhtmL/HTMLファイルURL": string;
}
