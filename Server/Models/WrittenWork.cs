using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class WrittenWork
{
  public required string Id { get; set; }

  [Column("作品名")]
  public required string Title { get; set; }

  [Column("作品名読み")]
  public required string TitleReading { get; set; }

  [Column("ソート用読み")]
  public required string TitleSort { get; set; }

  [Column("副題")]
  public string? Subtitle { get; set; }

  [Column("副題読み")]
  public string? SubtitleReading { get; set; }

  [Column("原題")]
  public string? OriginalTitle { get; set; }

  [Column("初出")]
  public string? ReleaseInfo { get; set; }

  [Column("文字使い種別ID")]
  public required string WritingStyleId { get; set; }
  public WritingStyle? WritingStyle { get; set; }

  [Column("作品著作権フラグ")]
  public bool WorkCopyright { get; set; } = false;

  [Column("人物ID")]
  public required string AuthorId { get; set; }
  public Author? Author { get; set; }

  [Column("役割フラグID")]
  public required string WriterRoleId { get; set; }
  public WriterRole? WriterRole { get; set; }

  [Column("底本ID")]
  public string? SourceId { get; set; }
  public Source? Source { get; set; }

  [Column("底本2ID")]
  public string? Source2Id { get; set; }
  public Source? Source2 { get; set; }

  [Column("テキストファイルURL")]
  public required string TextLink { get; set; }

  [Column("XHTML/HTMLファイルURL")]
  public required string XHTMLLink { get; set; }
}
