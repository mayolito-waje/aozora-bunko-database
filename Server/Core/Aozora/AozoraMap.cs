using System;
using CsvHelper.Configuration;

namespace Server.Core.Aozora;

public class AozoraMap : ClassMap<Aozora>
{
  public AozoraMap()
  {
    Map(m => m.WrittenWorkId).Name("作品ID");
    Map(m => m.Title).Name("作品名");
    Map(m => m.TitleReading).Name("作品名読み");
    Map(m => m.TitleSort).Name("ソート用読み");
    Map(m => m.Subtitle).Name("副題");
    Map(m => m.SubtitleReading).Name("副題読み");
    Map(m => m.OriginalTitle).Name("原題");
    Map(m => m.ReleaseInfo).Name("初出");
    Map(m => m.WritingStyle).Name("文字遣い種別");
    Map(m => m.WorkCopyright).Name("作品著作権フラグ");
    Map(m => m.AuthorId).Name("人物ID");
    Map(m => m.Surname).Name("姓");
    Map(m => m.GivenName).Name("名");
    Map(m => m.SurnameReading).Name("姓読み");
    Map(m => m.GivenNameReading).Name("名読み");
    Map(m => m.SurnameSort).Name("姓読みソート用");
    Map(m => m.GivenNameSort).Name("名読みソート用");
    Map(m => m.SurnameRomaji).Name("姓ローマ字");
    Map(m => m.GivenNameRomaji).Name("名ローマ字");
    Map(m => m.WriterRole).Name("役割フラグ");
    Map(m => m.BirthDate).Name("生年月日");
    Map(m => m.DeathDate).Name("没年月日");
    Map(m => m.PersonalityRights).Name("人物著作権フラグ");
    Map(m => m.Source).Name("底本名1");
    Map(m => m.SourcePublisher).Name("底本出版社名1");
    Map(m => m.SourcePublishDate).Name("底本初版発行年1");
    Map(m => m.OriginalSource).Name("底本の親本名1");
    Map(m => m.OriginalSourcePublisher).Name("底本の親本出版社名1");
    Map(m => m.OriginalSourcePublishDate).Name("底本の親本初版発行年1");
    Map(m => m.Source2).Name("底本名2");
    Map(m => m.SourcePublisher2).Name("底本出版社名2");
    Map(m => m.SourcePublishDate2).Name("底本初版発行年2");
    Map(m => m.OriginalSource2).Name("底本の親本名2");
    Map(m => m.OriginalSourcePublisher2).Name("底本の親本出版社名2");
    Map(m => m.OriginalSourcePublishDate2).Name("底本の親本初版発行年2");
    Map(m => m.TextLink).Name("テキストファイルURL");
    Map(m => m.XHTMLLink).Name("XHTML/HTMLファイルURL");
  }
}
