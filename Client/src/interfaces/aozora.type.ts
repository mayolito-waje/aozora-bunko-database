export interface WrittenWorksAuthor {
  id: string;
  surname: string;
  surnameReading: string;
  surnameSort: string;
  surnameRomaji: string;
  givenName: string;
  givenNameReading: string;
  givenNameSort: string;
  givenNameRomaji: string;
  birthDate: string;
  deathDate: string;
  personalityRights: boolean;
}

export interface Source {
  id: string;
  name: string;
  publisherId?: string;
  publisherName?: string;
  publishDateInfo?: string;
  originalSourceId?: string;
  originalSourceName?: string;
  originalSourcePublisherId?: string;
  originalSourcePublisherName?: string;
  originalSourcePublishDateInfo?: string;
}

export interface WrittenWorks {
  id: string;
  title: string;
  titleReading: string;
  titleSort: string;
  subtitle: string;
  subtitleReading: string;
  originalTitle: string;
  releaseInfo: string;
  writingStyle: string;
  workCopyright: boolean;
  author: WrittenWorksAuthor;
  writerRole: string;
  source?: Source;
  source2?: Source;
  textLink: string;
  htmlLink: string;
}
