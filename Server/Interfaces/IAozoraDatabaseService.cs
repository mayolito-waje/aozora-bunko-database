using Server.Data;

namespace Server.Interfaces;

public interface IAozoraDatabaseService
{
  Task PopulateAozoraDatabase(string csvPath);
}
