using Microsoft.Extensions.Configuration;

namespace AjKpi.Database.Seeders;

public class LookupSeeder : ISeeder
{
    public async Task SeedAsync(Context context, IConfiguration configuration)
    {
        var lookupSet = context.Set<Lookup>();

        var lookups = new List<Lookup>()
        {
            new Lookup()
            {
                Code = "KPIType",
                NameAr = "نوع المؤشر",
                NameEn = "KPI Type",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "FeudalKPI",
                        NameAr = "مؤشر اقطاعي",
                        NameEn = "Feudal KPI"
                    },
                    new LookupValue()
                    {
                        Code = "StrategicKPI",
                        NameAr = "مؤشر استراتيجي",
                        NameEn = "Strategic KPI"
                    },
                    new LookupValue()
                    {
                        Code = "StatisticalOperationsKPI",
                        NameAr = "مؤشر عمليات إحصائية",
                        NameEn = "Statistical Operations KPI"
                    },
                    new LookupValue()
                    {
                        Code = "SupportOperationsKPI",
                        NameAr = "مؤشر عمليات دعم",
                        NameEn = "Support Operations KPI"
                    },
                    new LookupValue()
                    {
                        Code = "KeyOperationsKPI",
                        NameAr = "مؤشر عمليات رئيسية",
                        NameEn = "Key Operations KPI"
                    },
                    new LookupValue()
                    {
                        Code = "NationalKPI",
                        NameAr = "مؤشر وطني",
                        NameEn = "National KPI"
                    },
                }
            },
            new Lookup()
            {
                Code = "MeasurementUnit",
                NameAr = "وحدة القياس",
                NameEn = "Measurement Unit",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "Minute",
                        NameAr = "دقيقة",
                        NameEn = "Minute"
                    },
                    new LookupValue()
                    {
                        Code = "Number",
                        NameAr = "رقم",
                        NameEn = "Number"
                    },
                    new LookupValue()
                    {
                        Code = "Hour",
                        NameAr = "ساعة",
                        NameEn = "Hour"
                    },
                    new LookupValue()
                    {
                        Code = "Currency",
                        NameAr = "عملة",
                        NameEn = "Currency"
                    },
                    new LookupValue()
                    {
                        Code = "ArithmeticAverage",
                        NameAr = "متوسط حسابي",
                        NameEn = "Arithmetic Average"
                    },
                    new LookupValue()
                    {
                        Code = "Average",
                        NameAr = "معدل",
                        NameEn = "Average"
                    },
                    new LookupValue()
                    {
                        Code = "Ratio",
                        NameAr = "نسبة",
                        NameEn = "Ratio"
                    },
                    new LookupValue()
                    {
                        Code = "Time",
                        NameAr = "وقت",
                        NameEn = "Time"
                    },
                }
            },
            new Lookup()
            {
                Code = "MeasurementCycle",
                NameAr = "دورة القياس",
                NameEn = "Measurement Cycle",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "Annual",
                        NameAr = "سنوي",
                        NameEn = "Annual"
                    },
                    new LookupValue()
                    {
                        Code = "Biannual",
                        NameAr = "نصف سنوي",
                        NameEn = "Biannual"
                    },
                    new LookupValue()
                    {
                        Code = "Quarterly",
                        NameAr = "ربع سنوي",
                        NameEn = "Quarterly"
                    },
                    new LookupValue()
                    {
                        Code = "Monthly",
                        NameAr = "شهري",
                        NameEn = "Monthly"
                    }
                }
            },
            new Lookup()
            {
                Code = "AggregateCoefficientValuesMethod",
                NameAr = "طريقة تجميع قيم المعامل",
                NameEn = "Aggregate Coefficient Values Method",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "LastValue",
                        NameAr = "اخر قيمة",
                        NameEn = "Last Value"
                    },
                    new LookupValue()
                    {
                        Code = "Adding",
                        NameAr = "جمع",
                        NameEn = "Adding"
                    },
                    new LookupValue()
                    {
                        Code = "Average",
                        NameAr = "متوسط",
                        NameEn = "Average"
                    },
                }
            },
            new Lookup()
            {
                Code = "InputMethod",
                NameAr = "طريقة الادخال",
                NameEn = "Input Method",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "OndemandInput",
                        NameAr = "الادخال عند الطلب - يدوي",
                        NameEn = "OnDemand Input Manual"
                    },
                    new LookupValue()
                    {
                        Code = "FlexibleInput",
                        NameAr = "الادخال المرن",
                        NameEn = "Flexible Input"
                    },
                }
            },
            new Lookup()
            {
                Code = "IndicatorModularity",
                NameAr = "نمطية المؤشر",
                NameEn = "Indicator Modularity",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "Betterlift",
                        NameAr = "رفع أفضل",
                        NameEn = "Better lift"
                    },
                    new LookupValue()
                    {
                        Code = "BetterCut",
                        NameAr = "خفض أفضل",
                        NameEn = "Better Cut"
                    },
                }
            },
            new Lookup()
            {
                Code = "KPIsource",
                NameAr = "مصدر المؤشر",
                NameEn = "KPI source",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "Internal",
                        NameAr = "داخلي",
                        NameEn = "Internal"
                    },
                    new LookupValue()
                    {
                        Code = "External",
                        NameAr = "خارجي",
                        NameEn = "External"
                    },
                }
            },
            new Lookup()
            {
                Code = "KPIClassification",
                NameAr = "تصنيف المؤشر",
                NameEn = "KPI Classification",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "NationalKPI",
                        NameAr = "المؤشرات الوطنية",
                        NameEn = "National KPI"
                    },
                    new LookupValue()
                    {
                        Code = "ExperimentalClassification",
                        NameAr = "تصنيف تجريبي",
                        NameEn = "Experimental Classification"
                    },
                    new LookupValue()
                    {
                        Code = "QualityOfLife",
                        NameAr = "جودة الحياة",
                        NameEn = "Quality of Life"
                    },
                }
            },
            new Lookup()
            {
                Code = "TheAxisoftheBalancedScorecardoftheKPI",
                NameAr = "محور بطاقة الاداء المتوازن للمؤشر",
                NameEn = "The Axis of the Balanced Scorecard of the KPI",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "FocusofAchievingMission",
                        NameAr = "محور تحقيق الرسالة",
                        NameEn = "Focus of Achieving Mission"
                    },
                    new LookupValue()
                    {
                        Code = "Handlers",
                        NameAr = "المتعاملين",
                        NameEn = "Handlers"
                    },
                    new LookupValue()
                    {
                        Code = "InternalOperations",
                        NameAr = "العمليات الداخلية",
                        NameEn = "Internal Operations"
                    },
                    new LookupValue()
                    {
                        Code = "LearningAndGrowth",
                        NameAr = "التعلم والنمو",
                        NameEn = "Learning and Growth"
                    },
                }
            },
            new Lookup()
            {
                Code = "KpiStatus",
                NameAr = "حالة مؤشر الاداء",
                NameEn = "Kpi Status",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "Draft",
                        NameAr = "مسودة",
                        NameEn = "Draft"
                    },
                    new LookupValue()
                    {
                        Code = "Approved",
                        NameAr = "تم الموافقة عليها",
                        NameEn = "Approved"
                    },
                    new LookupValue()
                    {
                        Code = "Submitted",
                        NameAr = "مرسلة",
                        NameEn = "Submitted"
                    },
                    new LookupValue()
                    {
                        Code = "ReSubmitted",
                        NameAr = "معاد ارسالها",
                        NameEn = "Re Submitted"
                    },
                    new LookupValue()
                    {
                        Code = "Rejected",
                        NameAr = "مرفوضة",
                        NameEn = "Rejected"
                    },
                    new LookupValue()
                    {
                        Code = "InProgress",
                        NameAr = "تحت الاجراء",
                        NameEn = "In Progress"
                    },
                    new LookupValue()
                    {
                        Code = "ReturnForUpdate",
                        NameAr = "إعادة للتعديل",
                        NameEn = "Return For Update"
                    },
                }
            },
            new Lookup()
            {
                Code = "MathematicalEquationAb",
                NameAr = "المعادلة الحسابية AB",
                NameEn = "Mathematical Equation AB",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "A/B",
                        NameAr = "A/B *100",
                        NameEn = "A/B *100"
                    },
                    new LookupValue()
                    {
                        Code = "A*100",
                        NameAr = "A*100",
                        NameEn = "A*100"
                    },
                    new LookupValue()
                    {
                        Code = "A+B*100/100",
                        NameAr = "A+B*100/100",
                        NameEn = "A+B*100/100"
                    }
                }
            },
            new Lookup()
            {
                Code = "Polarity",
                NameAr = "القطبية",
                NameEn = "Polarity",
                _lookupValues = new List<LookupValue>()
                {
                    new LookupValue()
                    {
                        Code = "Positive",
                        NameAr = "Positive",
                        NameEn = "موجب"
                    },
                    new LookupValue()
                    {
                        Code = "Negative",
                        NameAr = "Negative",
                        NameEn = "سالب"
                    }
                }
            },
            new Lookup()
            {
                Code = "Politics",
                NameAr = "السياسة",
                NameEn = "Politics",
            },
            new Lookup()
            {
                Code = "QualityOfLife",
                NameAr = "جودة الحياة",
                NameEn = "Quality Of Life",
            },
            new Lookup()
            {
                Code = "Risk",
                NameAr = "المخاطر",
                NameEn = "Risk",
            },
            new Lookup()
            {
                Code = "SustainableDevelopmentGoals",
                NameAr = "اهداف التنمية المستدامة",
                NameEn = "Sustainable Development Goals",
            },



        };


         foreach (var lookupData in lookups)
        {
            var existingLookup = await lookupSet
                .Include(l => l.LookupValues)
                .FirstOrDefaultAsync(l => l.Code == lookupData.Code);

            if (existingLookup != null)
            {
                // Update existing lookup
                existingLookup.NameAr = lookupData.NameAr;
                existingLookup.NameEn = lookupData.NameEn;

                // Update/Add lookup values
                foreach (var valueData in lookupData._lookupValues)
                {
                    var existingValue = existingLookup.LookupValues
                        .FirstOrDefault(v => v.Code == valueData.Code);

                    if (existingValue != null)
                    {
                        // Update existing value
                        existingValue.NameAr = valueData.NameAr;
                        existingValue.NameEn = valueData.NameEn;
                    }
                    else
                    {
                        // Add new value
                        existingLookup._lookupValues.Add(new LookupValue
                        {
                            Code = valueData.Code,
                            NameAr = valueData.NameAr,
                            NameEn = valueData.NameEn
                        });
                    }
                }

                // Remove values that no longer exist in the source data
                var valuesToRemove = existingLookup.LookupValues
                    .Where(v => !lookupData.LookupValues.Any(newV => newV.Code == v.Code))
                    .ToList();

                foreach (var valueToRemove in valuesToRemove)
                {
                    existingLookup._lookupValues.Remove(valueToRemove);
                }

                lookupSet.Update(existingLookup);
            }
            else
            {
                // Create new lookup with its values
                // var newLookup = new Lookup
                // {
                //     Code = lookupData.Code,
                //     NameAr = lookupData.NameAr,
                //     NameEn = lookupData.NameEn,
                //     _lookupValues = lookupData._lookupValues.Select(v => new LookupValue
                //     {
                //         Code = v.Code,
                //         NameAr = v.NameAr,
                //         NameEn = v.NameEn
                //     }).ToList()
                // };

                lookupSet.Add(lookupData);
            }
        }

        await context.SaveChangesAsync();

    }
}
