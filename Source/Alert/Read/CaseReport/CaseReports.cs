using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Read
{
    public class CaseReports : Repository<CaseReport>, ICaseReports
    {
        public CaseReports(IMongoDatabase database) : base(database, "CaseReport")
        {
        }

        public IEnumerable<CaseReport> GetCaseReportsAfterDate(DateTime date, Guid diseaseId)
        {
            return _collection.FindSync(report => report.SubmissionTimestamp > date && report.DiseaseId == diseaseId).ToEnumerable();
        }
    }
}
