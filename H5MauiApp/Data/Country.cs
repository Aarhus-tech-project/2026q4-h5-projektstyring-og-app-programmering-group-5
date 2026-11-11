namespace H5MauiApp.Data;

using System.Collections.Generic;

public sealed class Country
{
    public int Id { get; }
    public string Code { get; }
    public string Name { get; }
    public string Continent { get; }
    public string WikipediaLink { get; }
    public string Keywords { get; }

    public Country(
        int id,
        string code,
        string name,
        string continent,
        string wikipediaLink,
        string keywords
    )
    {
        Id = id;
        Code = code;
        Name = name;
        Continent = continent;
        WikipediaLink = wikipediaLink;
        Keywords = keywords;
    }
}

public static class CountryData
{
    private const string WikipediaBase = "https://en.wikipedia.org/wiki/";

    public static readonly List<Country> Countries = new List<Country>
    {
        new Country(
            302672, "AD", "Andorra", "EU",
            WikipediaBase + "Andorra",
            "Andorran airports"
        ),
        new Country(
            302618, "AE", "United Arab Emirates", "AS",
            WikipediaBase + "United_Arab_Emirates",
            "UAE,مطارات في الإمارات العربية المتحدة"
        ),
        new Country(
            302619, "AF", "Afghanistan", "AS",
            WikipediaBase + "Afghanistan",
            ""
        ),
        new Country(
            302722, "AG", "Antigua and Barbuda", "NA",
            WikipediaBase + "Antigua_and_Barbuda",
            "Antiguan airports"
        ),
        new Country(
            302723, "AI", "Anguilla", "NA",
            WikipediaBase + "Anguilla",
            ""
        ),
        new Country(
            302673, "AL", "Albania", "EU",
            WikipediaBase + "Albania",
            "Albanian airports"
        ),
        new Country(
            302620, "AM", "Armenia", "AS",
            WikipediaBase + "Armenia",
            ""
        ),
        new Country(
            302556, "AO", "Angola", "AF",
            WikipediaBase + "Angola",
            "Angolan airports"
        ),
        new Country(
            302615, "AQ", "Antarctica", "AN",
            WikipediaBase + "Antarctica",
            "Airports in Antarctica"
        ),
        new Country(
            302789, "AR", "Argentina", "SA",
            WikipediaBase + "Argentina",
            "Aeropuertos de Argentina"
        ),
        new Country(
            302763, "AS", "American Samoa", "OC",
            WikipediaBase + "American_Samoa",
            "Samoan airports"
        ),
        new Country(
            302674, "AT", "Austria", "EU",
            WikipediaBase + "Austria",
            "Flughäfen in Österreich"
        ),
        new Country(
            302764, "AU", "Australia", "OC",
            WikipediaBase + "Australia",
            "Australian airports"
        ),
        new Country(
            302725, "AW", "Aruba", "NA",
            WikipediaBase + "Aruba",
            ""
        ),
        new Country(
            302621, "AZ", "Azerbaijan", "AS",
            WikipediaBase + "Azerbaijan",
            "Azerbaijani airports"
        ),
        new Country(
            302675, "BA", "Bosnia and Herzegovina", "EU",
            WikipediaBase + "Bosnia_and_Herzegovina",
            "Bosnian airports"
        ),
        new Country(
            302726, "BB", "Barbados", "NA",
            WikipediaBase + "Barbados",
            "Barbadan airports"
        ),
        new Country(
            302622, "BD", "Bangladesh", "AS",
            WikipediaBase + "Bangladesh",
            "Bangladeshi airports"
        ),
        new Country(
            302676, "BE", "Belgium", "EU",
            WikipediaBase + "Belgium",
            "Aéroports de Belgique,Luchthavens van België"
        ),
        new Country(
            302557, "BF", "Burkina Faso", "AF",
            WikipediaBase + "Burkina_Faso",
            "Burkinabé airports"
        ),
        new Country(
            302677, "BG", "Bulgaria", "EU",
            WikipediaBase + "Bulgaria",
            "Bulgarian airports"
        ),
        new Country(
            302623, "BH", "Bahrain", "AS",
            WikipediaBase + "Bahrain",
            "مطارات البحرين"
        ),
        new Country(
            302558, "BI", "Burundi", "AF",
            WikipediaBase + "Burundi",
            "Burundian airports"
        ),
        new Country(
            302559, "BJ", "Benin", "AF",
            WikipediaBase + "Benin",
            "Beninese airports"
        ),
        new Country(
            302760, "BL", "Saint Barthélemy", "NA",
            WikipediaBase + "Saint_Barthélemy",
            "Airports in Saint Barthélemy"
        ),
        new Country(
            302727, "BM", "Bermuda", "NA",
            WikipediaBase + "Bermuda",
            ""
        ),
        new Country(
            302624, "BN", "Brunei", "AS",
            WikipediaBase + "Brunei",
            "Bruneian airports"
        ),
        new Country(
            302790, "BO", "Bolivia", "SA",
            WikipediaBase + "Bolivia",
            "Aeropuertos de Bolivia"
        ),
        new Country(
            302724, "BQ", "Caribbean Netherlands", "NA",
            WikipediaBase + "Caribbean_Netherlands",
            "Airports in Caribbean Netherlands"
        ),
        new Country(
            302791, "BR", "Brazil", "SA",
            WikipediaBase + "Brazil",
            "Brasil, Brasilian, Aeroportos do Brasil"
        ),
        new Country(
            302728, "BS", "Bahamas", "NA",
            WikipediaBase + "Bahamas",
            "Bahaman airports"
        ),
        new Country(
            302625, "BT", "Bhutan", "AS",
            WikipediaBase + "Bhutan",
            "Bhutanese airports"
        ),
        new Country(
            302560, "BW", "Botswana", "AF",
            WikipediaBase + "Botswana",
            "Botswana airports"
        ),
        new Country(
            302678, "BY", "Belarus", "EU",
            WikipediaBase + "Belarus",
            "Belarussian, Беларусь"
        ),
        new Country(
            302729, "BZ", "Belize", "NA",
            WikipediaBase + "Belize",
            "Belizean airports"
        ),
        new Country(
            302730, "CA", "Canada", "NA",
            WikipediaBase + "Canada",
            "Canadian airports"
        ),
        new Country(
            302626, "CC", "Cocos (Keeling) Islands", "AS",
            WikipediaBase + "Cocos_(Keeling)_Islands",
            "Airports in Cocos (Keeling) Islands"
        ),
        new Country(
            302561, "CD", "Democratic Republic of the Congo", "AF",
            WikipediaBase + "Democratic_Republic_of_the_Congo",
            "DRC"
        ),
        new Country(
            302562, "CF", "Central African Republic", "AF",
            WikipediaBase + "Central_African_Republic",
            "Airports in Central African Republic"
        ),
        new Country(
            302563, "CG", "Republic of the Congo", "AF",
            WikipediaBase + "Republic_of_the_Congo",
            "Congo-Brazzaville"
        ),
        new Country(
            302679, "CH", "Switzerland", "EU",
            WikipediaBase + "Switzerland",
            "Aéroports de la Suisse,Flughäfen der Schweiz"
        ),
        new Country(
            302564, "CI", "Côte d'Ivoire", "AF",
            WikipediaBase + "Côte_d'Ivoire",
            "Ivory Coast"
        ),
        new Country(
            302765, "CK", "Cook Islands", "OC",
            WikipediaBase + "Cook_Islands",
            "Airports in Cook Islands"
        ),
        new Country(
            302792, "CL", "Chile", "SA",
            WikipediaBase + "Chile",
            "Aeropuertos de Chile"
        ),
        new Country(
            302565, "CM", "Cameroon", "AF",
            WikipediaBase + "Cameroon",
            "Cameroonian airports"
        ),
        new Country(
            302627, "CN", "China", "AS",
            WikipediaBase + "China",
            "中国的机场"
        ),
        new Country(
            302793, "CO", "Colombia", "SA",
            WikipediaBase + "Colombia",
            "Aeropuertos de Colombia"
        ),
        new Country(
            302731, "CR", "Costa Rica", "NA",
            WikipediaBase + "Costa_Rica",
            "Aeropuertos de Costa Rica"
        ),
        new Country(
            302732, "CU", "Cuba", "NA",
            WikipediaBase + "Cuba",
            "Aeropuertos de Cuba"
        ),
        new Country(
            302566, "CV", "Cape Verde", "AF",
            WikipediaBase + "Cape_Verde",
            "Airports in Cape Verde"
        ),
        new Country(
            302762, "CW", "Curaçao", "NA",
            WikipediaBase + "Cura%C3%A7ao",
            "Airports in Curaçao"
        ),
        new Country(
            302628, "CX", "Christmas Island", "AS",
            WikipediaBase + "Christmas_Island",
            "Airports in Christmas Island"
        ),
        new Country(
            302629, "CY", "Cyprus", "AS",
            WikipediaBase + "Cyprus",
            "Cypriot airports"
        ),
        new Country(
            302680, "CZ", "Czech Republic", "EU",
            WikipediaBase + "Czech_Republic",
            "Letiště České republiky, Czechia"
        ),
        new Country(
            302681, "DE", "Germany", "EU",
            WikipediaBase + "Germany",
            "Flughäfen in Deutschland"
        ),
        new Country(
            302567, "DJ", "Djibouti", "AF",
            WikipediaBase + "Djibouti",
            "Djiboutian airports"
        ),
        new Country(
            302682, "DK", "Denmark", "EU",
            WikipediaBase + "Denmark",
            "Lufthavnene i Danmark"
        ),
        new Country(
            302733, "DM", "Dominica", "NA",
            WikipediaBase + "Dominica",
            "Airports in Dominica"
        ),
        new Country(
            302734, "DO", "Dominican Republic", "NA",
            WikipediaBase + "Dominican_Republic",
            "Airports in Dominican Republic"
        ),
        new Country(
            302568, "DZ", "Algeria", "AF",
            WikipediaBase + "Algeria",
            "مطارات الجزائر"
        ),
        new Country(
            302794, "EC", "Ecuador", "SA",
            WikipediaBase + "Ecuador",
            "Aeropuertos de Ecuador"
        ),
        new Country(
            302683, "EE", "Estonia", "EU",
            WikipediaBase + "Estonia",
            "Estonian airports"
        ),
        new Country(
            302569, "EG", "Egypt", "AF",
            WikipediaBase + "Egypt",
            "مطارات مصر, Egyptian airports"
        ),
        new Country(
            302570, "EH", "Western Sahara (disputed territory)", "AF",
            WikipediaBase + "Western_Sahara",
            "Sahrawian, مطارات الصحراء الغربية"
        ),
        new Country(
            302571, "ER", "Eritrea", "AF",
            WikipediaBase + "Eritrea",
            "Eritrean airports"
        ),
        new Country(
            302684, "ES", "Spain", "EU",
            WikipediaBase + "Spain",
            "Aeropuertos de España"
        ),
        new Country(
            302572, "ET", "Ethiopia", "AF",
            WikipediaBase + "Ethiopia",
            "Ethiopian airports"
        ),
        new Country(
            302685, "FI", "Finland", "EU",
            WikipediaBase + "Finland",
            "Lentokentät, Suomen"
        ),
        new Country(
            302766, "FJ", "Fiji", "OC",
            WikipediaBase + "Fiji",
            "Fijan airports"
        ),
        new Country(
            302795, "FK", "Falkland Islands", "SA",
            WikipediaBase + "Falkland_Islands",
            "Airports in Falkland Islands"
        ),
        new Country(
            302767, "FM", "Micronesia", "OC",
            WikipediaBase + "Federated_States_of_Micronesia",
            "Micronesian airports"
        ),
        new Country(
            302686, "FO", "Faroe Islands", "EU",
            WikipediaBase + "Faroe_Islands",
            "Faroese airports"
        ),
        new Country(
            302687, "FR", "France", "EU",
            WikipediaBase + "France",
            "Aéroports de France"
        ),
        new Country(
            302573, "GA", "Gabon", "AF",
            WikipediaBase + "Gabon",
            "Gabonese airports"
        ),
        new Country(
            302688, "GB", "United Kingdom", "EU",
            WikipediaBase + "United_Kingdom",
            "Great Britain"
        ),
        new Country(
            302735, "GD", "Grenada", "NA",
            WikipediaBase + "Grenada",
            "Grenadian airports"
        ),
        new Country(
            302630, "GE", "Georgia", "AS",
            WikipediaBase + "Georgia_(country)",
            "Georgian airports"
        ),
        new Country(
            302796, "GF", "French Guiana", "SA",
            WikipediaBase + "French_Guiana",
            "French Guyana"
        ),
        new Country(
            302689, "GG", "Guernsey", "EU",
            WikipediaBase + "Guernsey",
            "Airports in Guernsey"
        ),
        new Country(
            302574, "GH", "Ghana", "AF",
            WikipediaBase + "Ghana",
            "Ghanan airports"
        ),
        new Country(
            302690, "GI", "Gibraltar", "EU",
            WikipediaBase + "Gibraltar",
            "Gibraltarian airports"
        ),
        new Country(
            302736, "GL", "Greenland", "NA",
            WikipediaBase + "Greenland",
            "Airports in Greenland"
        ),
        new Country(
            302575, "GM", "Gambia", "AF",
            WikipediaBase + "Gambia",
            "Gambian airports"
        ),
        new Country(
            302576, "GN", "Guinea", "AF",
            WikipediaBase + "Guinea",
            "Aéroports de la Guinée"
        ),
        new Country(
            302737, "GP", "Guadeloupe", "NA",
            WikipediaBase + "Guadeloupe",
            "Airports in Guadeloupe"
        ),
        new Country(
            302577, "GQ", "Equatorial Guinea", "AF",
            WikipediaBase + "Equatorial_Guinea",
            "Airports in Equatorial Guinea"
        ),
        new Country(
            302691, "GR", "Greece", "EU",
            WikipediaBase + "Greece",
            "αεροδρόμια στην Ελλάδα"
        ),
        new Country(
            302616,
            "GS",
            "South Georgia and the South Sandwich Islands",
            "AN",
            WikipediaBase + "South_Georgia_and_the_South_Sandwich_Islands",
            "Airports in South Georgia and the South Sandwich Islands"
        ),
        new Country(
            302738, "GT", "Guatemala", "NA",
            WikipediaBase + "Guatemala",
            "Aeropuertos de Guatemala"
        ),
        new Country(
            302768, "GU", "Guam", "OC",
            WikipediaBase + "Guam",
            "Guamanian airports"
        ),
        new Country(
            302578, "GW", "Guinea-Bissau", "AF",
            WikipediaBase + "Guinea-Bissau",
            "Airports in Guinea-Bissau"
        ),
        new Country(
            302797, "GY", "Guyana", "SA",
            WikipediaBase + "Guyana",
            "Guyanese airports"
        ),
        new Country(
            302631, "HK", "Hong Kong", "AS",
            WikipediaBase + "Hong_Kong",
            "Airports in Hong Kong"
        ),
        new Country(
            350209, "HM", "Heard and McDonald Islands", "OC",
            WikipediaBase + "Heard_Island_and_McDonald_Islands",
            "Airports in Heard and McDonald Islands"
        ),
        new Country(
            302739, "HN", "Honduras", "NA",
            WikipediaBase + "Honduras",
            "Aeropuertos de Honduras"
        ),
        new Country(
            302692, "HR", "Croatia", "EU",
            WikipediaBase + "Croatia",
            "Croatian airports"
        ),
        new Country(
            302740, "HT", "Haiti", "NA",
            WikipediaBase + "Haiti",
            "Aéroports de Haïti"
        ),
        new Country(
            302693, "HU", "Hungary", "EU",
            WikipediaBase + "Hungary",
            "Repülőterek Magyarország"
        ),
        new Country(
            302632, "ID", "Indonesia", "AS",
            WikipediaBase + "Indonesia",
            "Bandara di Indonesia"
        ),
        new Country(
            302694, "IE", "Ireland", "EU",
            WikipediaBase + "Ireland",
            "Eire"
        ),
        new Country(
            302633, "IL", "Israel", "AS",
            WikipediaBase + "Israel",
            "שדות התעופה של ישראל"
        ),
        new Country(
            302695, "IM", "Isle of Man", "EU",
            WikipediaBase + "Isle_of_Man",
            "Manx"
        ),
        new Country(
            302634, "IN", "India", "AS",
            WikipediaBase + "India",
            "Airports in India, Indian airports"
        ),
        new Country(
            302635, "IO", "British Indian Ocean Territory", "AS",
            WikipediaBase + "British_Indian_Ocean_Territory",
            "Airports in British Indian Ocean Territory"
        ),
        new Country(
            302636, "IQ", "Iraq", "AS",
            WikipediaBase + "Iraq",
            "مطارات العراق"
        ),
        new Country(
            302637, "IR", "Iran", "AS",
            WikipediaBase + "Iran",
            "فرودگاه های ایران"
        ),
        new Country(
            302696, "IS", "Iceland", "EU",
            WikipediaBase + "Iceland",
            "Icelandic airports"
        ),
        new Country(
            302697, "IT", "Italy", "EU",
            WikipediaBase + "Italy",
            "Aeroporti d'Italia"
        ),
        new Country(
            302698, "JE", "Jersey", "EU",
            WikipediaBase + "Jersey",
            "Airports in Jersey"
        ),
        new Country(
            302741, "JM", "Jamaica", "NA",
            WikipediaBase + "Jamaica",
            "Jamaican airports"
        ),
        new Country(
            302638, "JO", "Jordan", "AS",
            WikipediaBase + "Jordan",
            "مطارات في الأردن"
        ),
        new Country(
            302639, "JP", "Japan", "AS",
            WikipediaBase + "Japan",
            "Nippon, 日本の空港"
        ),
        new Country(
            302579, "KE", "Kenya", "AF",
            WikipediaBase + "Kenya",
            "Kenyan airports"
        ),
        new Country(
            302640, "KG", "Kyrgyzstan", "AS",
            WikipediaBase + "Kyrgyzstan",
            ""
        ),
        new Country(
            302641, "KH", "Cambodia", "AS",
            WikipediaBase + "Cambodia",
            "Cambodian airports"
        ),
        new Country(
            302769, "KI", "Kiribati", "OC",
            WikipediaBase + "Kiribati",
            "Airports in Kiribati"
        ),
        new Country(
            302580, "KM", "Comoros", "AF",
            WikipediaBase + "Comoros",
            "جزر القمر"
        ),
        new Country(
            302742, "KN", "Saint Kitts and Nevis", "NA",
            WikipediaBase + "Saint_Kitts_and_Nevis",
            "Airports in Saint Kitts and Nevis"
        ),
        new Country(
            302642, "KP", "North Korea", "AS",
            WikipediaBase + "North_Korea",
            "North Korean airports"
        ),
        new Country(
            302643, "KR", "South Korea", "AS",
            WikipediaBase + "South_Korea",
            "한국의 공항"
        ),
        new Country(
            302644, "KW", "Kuwait", "AS",
            WikipediaBase + "Kuwait",
            "Kuwaiti airports"
        ),
        new Country(
            302743, "KY", "Cayman Islands", "NA",
            WikipediaBase + "Cayman_Islands",
            "Airports in Cayman Islands"
        ),
        new Country(
            302645, "KZ", "Kazakhstan", "AS",
            WikipediaBase + "Kazakhstan",
            "Kazakh"
        ),
        new Country(
            302646, "LA", "Laos", "AS",
            WikipediaBase + "Laos",
            "Laotian airports"
        ),
        new Country(
            302647, "LB", "Lebanon", "AS",
            WikipediaBase + "Lebanon",
            "المطارات في لبنان"
        ),
        new Country(
            302744, "LC", "Saint Lucia", "NA",
            WikipediaBase + "Saint_Lucia",
            "Airports in Saint Lucia"
        ),
        new Country(
            302699, "LI", "Liechtenstein", "EU",
            WikipediaBase + "Liechtenstein",
            "Airports in Liechtenstein"
        ),
        new Country(
            302648, "LK", "Sri Lanka", "AS",
            WikipediaBase + "Sri_Lanka",
            "Sri Lankan airports"
        ),
        new Country(
            302581, "LR", "Liberia", "AF",
            WikipediaBase + "Liberia",
            ""
        ),
        new Country(
            302582, "LS", "Lesotho", "AF",
            WikipediaBase + "Lesotho",
            "Airports in Lesotho"
        ),
        new Country(
            302700, "LT", "Lithuania", "EU",
            WikipediaBase + "Lithuania",
            "Lithuanian airports"
        ),
        new Country(
            302701, "LU", "Luxembourg", "EU",
            WikipediaBase + "Luxembourg",
            "Airports in Luxembourg"
        ),
        new Country(
            302702, "LV", "Latvia", "EU",
            WikipediaBase + "Latvia",
            "Latvian airports"
        ),
        new Country(
            302583, "LY", "Libya", "AF",
            WikipediaBase + "Libya",
            "مطارات في ليبيا"
        ),
        new Country(
            302584, "MA", "Morocco", "AF",
            WikipediaBase + "Morocco",
            "مطارات المغرب"
        ),
        new Country(
            302703, "MC", "Monaco", "EU",
            WikipediaBase + "Monaco",
            "Airports in Monaco"
        ),
        new Country(
            302704, "MD", "Moldova", "EU",
            WikipediaBase + "Moldova",
            "Airports in Moldova"
        ),
        new Country(
            302705, "ME", "Montenegro", "EU",
            WikipediaBase + "Montenegro",
            "Montenegran airports"
        ),
        new Country(
            302759, "MF", "Saint Martin", "NA",
            WikipediaBase + "Saint_Martin_(France)",
            "Airports in Saint Martin"
        ),
        new Country(
            302585, "MG", "Madagascar", "AF",
            WikipediaBase + "Madagascar",
            "Airports in Madagascar"
        ),
        new Country(
            302770, "MH", "Marshall Islands", "OC",
            WikipediaBase + "Marshall_Islands",
            "Airports in Marshall Islands"
        ),
        new Country(
            302706, "MK", "North Macedonia", "EU",
            WikipediaBase + "Macedonia",
            "Macedonian airports"
        ),
        new Country(
            302586, "ML", "Mali", "AF",
            WikipediaBase + "Mali",
            "Aéroports du Mali, Malian airports"
        ),
        new Country(
            302649, "MM", "Myanmar", "AS",
            WikipediaBase + "Burma",
            "Myanmar"
        ),
        new Country(
            302650, "MN", "Mongolia", "AS",
            WikipediaBase + "Mongolia",
            "Mongolian airports"
        ),
        new Country(
            302651, "MO", "Macau", "AS",
            WikipediaBase + "Macau",
            "Macao"
        ),
        new Country(
            302771, "MP", "Northern Mariana Islands", "OC",
            WikipediaBase + "Northern_Mariana_Islands",
            "Airports in Northern Mariana Islands"
        ),
        new Country(
            302745, "MQ", "Martinique", "NA",
            WikipediaBase + "Martinique",
            "Airports in Martinique"
        ),
        new Country(
            302587, "MR", "Mauritania", "AF",
            WikipediaBase + "Mauritania",
            "مطارات موريتانيا"
        ),
        new Country(
            302746, "MS", "Montserrat", "NA",
            WikipediaBase + "Montserrat",
            "Airports in Montserrat"
        ),
        new Country(
            302707, "MT", "Malta", "EU",
            WikipediaBase + "Malta",
            ""
        ),
        new Country(
            302588, "MU", "Mauritius", "AF",
            WikipediaBase + "Mauritius",
            "Airports in Mauritius"
        ),
        new Country(
            302652, "MV", "Maldives", "AS",
            WikipediaBase + "Maldives",
            "Airports in Maldives"
        ),
        new Country(
            302589, "MW", "Malawi", "AF",
            WikipediaBase + "Malawi",
            "Airports in Malawi"
        ),
        new Country(
            302747, "MX", "Mexico", "NA",
            WikipediaBase + "Mexico",
            "Aeropuertos de México, Mexican airports"
        ),
        new Country(
            302653, "MY", "Malaysia", "AS",
            WikipediaBase + "Malaysia",
            "Lapangan Terbang Malaysia"
        ),
        new Country(
            302590, "MZ", "Mozambique", "AF",
            WikipediaBase + "Mozambique",
            "Airports in Mozambique"
        ),
        new Country(
            302591, "NA", "Namibia", "AF",
            WikipediaBase + "Namibia",
            ""
        ),
        new Country(
            302772, "NC", "New Caledonia", "OC",
            WikipediaBase + "New_Caledonia",
            "Airports in New Caledonia"
        ),
        new Country(
            302592, "NE", "Niger", "AF",
            WikipediaBase + "Niger",
            "Nigerien airports"
        ),
        new Country(
            302773, "NF", "Norfolk Island", "OC",
            WikipediaBase + "Norfolk_Island",
            "Airports in Norfolk Island"
        ),
        new Country(
            302593, "NG", "Nigeria", "AF",
            WikipediaBase + "Nigeria",
            ""
        ),
        new Country(
            302748, "NI", "Nicaragua", "NA",
            WikipediaBase + "Nicaragua",
            "Aeropuertos de Nicaragua"
        ),
        new Country(
            302708, "NL", "Netherlands", "EU",
            WikipediaBase + "Netherlands",
            "Holland, Luchthavens van Nederland, Dutch airports"
        ),
        new Country(
            302709, "NO", "Norway", "EU",
            WikipediaBase + "Norway",
            "Flyplasser i Norge"
        ),
        new Country(
            302654, "NP", "Nepal", "AS",
            WikipediaBase + "Nepal",
            "नेपाल विमानस्थलको"
        ),
        new Country(
            302774, "NR", "Nauru", "OC",
            WikipediaBase + "Nauru",
            "Airports in Nauru"
        ),
        new Country(
            302775, "NU", "Niue", "OC",
            WikipediaBase + "Niue",
            "Niuean airports"
        ),
        new Country(
            302776, "NZ", "New Zealand", "OC",
            WikipediaBase + "New_Zealand",
            "Airports in New Zealand"
        ),
        new Country(
            302655, "OM", "Oman", "AS",
            WikipediaBase + "Oman",
            "مطارات عمان"
        ),
        new Country(
            302749, "PA", "Panama", "NA",
            WikipediaBase + "Panama",
            "Aeropuertos de Panamá"
        ),
        new Country(
            302798, "PE", "Peru", "SA",
            WikipediaBase + "Perú",
            "Aeropuertos de Perú"
        ),
        new Country(
            302777, "PF", "French Polynesia", "OC",
            WikipediaBase + "French_Polynesia",
            ""
        ),
        new Country(
            302778, "PG", "Papua New Guinea", "OC",
            WikipediaBase + "Papua_New_Guinea",
            "Airports in Papua New Guinea"
        ),
        new Country(
            302656, "PH", "Philippines", "AS",
            WikipediaBase + "Philippines",
            "Mga alternatibong byahe mula sa Pilipinas"
        ),
        new Country(
            302657, "PK", "Pakistan", "AS",
            WikipediaBase + "Pakistan",
            "پاکستان کے ہوائی اڈوں"
        ),
        new Country(
            302710, "PL", "Poland", "EU",
            WikipediaBase + "Poland",
            "Lotniska Polski"
        ),
        new Country(
            302750, "PM", "Saint Pierre and Miquelon", "NA",
            WikipediaBase + "Saint_Pierre_and_Miquelon",
            "Airports in Saint Pierre and Miquelon"
        ),
        new Country(
            302779, "PN", "Pitcairn", "OC",
            WikipediaBase + "Pitcairn",
            "Airports in Pitcairn"
        ),
        new Country(
            302751, "PR", "Puerto Rico", "NA",
            WikipediaBase + "Puerto_Rico",
            ""
        ),
        new Country(
            302658, "PS", "Palestinian Territory", "AS",
            WikipediaBase + "Palestinian_Territory",
            "Palestinian airports"
        ),
        new Country(
            302711, "PT", "Portugal", "EU",
            WikipediaBase + "Portugal",
            "Aeroportos de Portugal"
        ),
        new Country(
            302780, "PW", "Palau", "OC",
            WikipediaBase + "Palau",
            "Palauan airports"
        ),
        new Country(
            302799, "PY", "Paraguay", "SA",
            WikipediaBase + "Paraguay",
            "Aeropuertos de Paraguay"
        ),
        new Country(
            302659, "QA", "Qatar", "AS",
            WikipediaBase + "Qatar",
            "مطارات قطر"
        ),
        new Country(
            302594, "RE", "Réunion", "AF",
            WikipediaBase + "Réunion",
            "Île Bourbon, La Réunion"
        ),
        new Country(
            302712, "RO", "Romania", "EU",
            WikipediaBase + "Romania",
            "Aeroporturi din România"
        ),
        new Country(
            302713, "RS", "Serbia", "EU",
            WikipediaBase + "Serbia",
            "Serb"
        ),
        new Country(
            302714, "RU", "Russia", "EU",
            WikipediaBase + "Russia",
            "Soviet, Sovietskaya, Sovetskaya, Аэропорты России"
        ),
        new Country(
            302595, "RW", "Rwanda", "AF",
            WikipediaBase + "Rwanda",
            ""
        ),
        new Country(
            302660, "SA", "Saudi Arabia", "AS",
            WikipediaBase + "Saudi_Arabia",
            "مطارات المملكة العربية السعودية,المطارات لموسم الحج"
        ),
        new Country(
            302781, "SB", "Solomon Islands", "OC",
            WikipediaBase + "Solomon_Islands",
            "Airports in Solomon Islands"
        ),
        new Country(
            302596, "SC", "Seychelles", "AF",
            WikipediaBase + "Seychelles",
            "Airports in Seychelles"
        ),
        new Country(
            302597, "SD", "Sudan", "AF",
            WikipediaBase + "Sudan",
            "مطارات السودان"
        ),
        new Country(
            302715, "SE", "Sweden", "EU",
            WikipediaBase + "Sweden",
            "Flygplatserna, Sverige"
        ),
        new Country(
            302661, "SG", "Singapore", "AS",
            WikipediaBase + "Singapore",
            "Singaporean airports"
        ),
        new Country(
            302598,
            "SH",
            "Saint Helena, Ascension and Tristan da Cunha",
            "AF",
            WikipediaBase + "Saint_Helena,_Ascension_and_Tristan_da_Cunha",
            "Airports in Saint Helena, Ascension and Tristan da Cunha"
        ),
        new Country(
            302716, "SI", "Slovenia", "EU",
            WikipediaBase + "Slovenia",
            ""
        ),
        new Country(
            302717, "SK", "Slovakia", "EU",
            WikipediaBase + "Slovakia",
            "letisko Slovenska"
        ),
        new Country(
            302599, "SL", "Sierra Leone", "AF",
            WikipediaBase + "Sierra_Leone",
            "Sierra Leonean airports"
        ),
        new Country(
            302718, "SM", "San Marino", "EU",
            WikipediaBase + "San_Marino",
            "Airports in San Marino"
        ),
        new Country(
            302600, "SN", "Senegal", "AF",
            WikipediaBase + "Senegal",
            "Aéroports du Sénégal, Senegalese airports"
        ),
        new Country(
            302601, "SO", "Somalia", "AF",
            WikipediaBase + "Somalia",
            ""
        ),
        new Country(
            302800, "SR", "Suriname", "SA",
            WikipediaBase + "Suriname",
            "Surinamese airports"
        ),
        new Country(
            302614, "SS", "South Sudan", "AF",
            WikipediaBase + "South_Sudan",
            "South Sudanese airports"
        ),
        new Country(
            302602, "ST", "São Tomé and Principe", "AF",
            WikipediaBase + "São_Tomé_and_Principe",
            "Airports in São Tomé and Principe"
        ),
        new Country(
            302752, "SV", "El Salvador", "NA",
            WikipediaBase + "El_Salvador",
            "Salvadorian, Salvadorean"
        ),
        new Country(
            302761, "SX", "Sint Maarten", "NA",
            WikipediaBase + "Sint_Maarten",
            "Airports in Sint Maarten"
        ),
        new Country(
            302662, "SY", "Syria", "AS",
            WikipediaBase + "Syria",
            "مطارات سوريا"
        ),
        new Country(
            302603, "SZ", "Eswatini", "AF",
            WikipediaBase + "Eswatini",
            "Swaziland"
        ),
        new Country(
            302753, "TC", "Turks and Caicos Islands", "NA",
            WikipediaBase + "Turks_and_Caicos_Islands",
            "Airports in Turks and Caicos Islands"
        ),
        new Country(
            302604, "TD", "Chad", "AF",
            WikipediaBase + "Chad",
            "Airports in Chad"
        ),
        new Country(
            302617, "TF", "French Southern and Antarctic Lands", "AF",
            WikipediaBase + "French_Southern_and_Antarctic_Lands",
            "Airports in French Southern and Antarctic Lands"
        ),
        new Country(
            302605, "TG", "Togo", "AF",
            WikipediaBase + "Togo",
            "Airports in Togo"
        ),
        new Country(
            302663, "TH", "Thailand", "AS",
            WikipediaBase + "Thailand",
            "Siam, Siamese"
        ),
        new Country(
            302664, "TJ", "Tajikistan", "AS",
            WikipediaBase + "Tajikistan",
            "Tajik"
        ),
        new Country(
            302782, "TK", "Tokelau", "OC",
            WikipediaBase + "Tokelau",
            "Airports in Tokelau"
        ),
        new Country(
            302665, "TL", "Timor-Leste", "AS",
            WikipediaBase + "Timor-Leste",
            "East Timor"
        ),
        new Country(
            302666, "TM", "Turkmenistan", "AS",
            WikipediaBase + "Turkmenistan",
            "Turkmenistani airports, Airports in Turkmenistan"
        ),
        new Country(
            302606, "TN", "Tunisia", "AF",
            WikipediaBase + "Tunisia",
            "مطارات تونس"
        ),
        new Country(
            302783, "TO", "Tonga", "OC",
            WikipediaBase + "Tonga",
            "Airports in Tonga"
        ),
        new Country(
            302667, "TR", "Turkey", "AS",
            WikipediaBase + "Turkey",
            "Türkiye havaalanları"
        ),
        new Country(
            302754, "TT", "Trinidad and Tobago", "NA",
            WikipediaBase + "Trinidad_and_Tobago",
            "Airports in Trinidad and Tobago"
        ),
        new Country(
            302784, "TV", "Tuvalu", "OC",
            WikipediaBase + "Tuvalu",
            "Airports in Tuvalu"
        ),
        new Country(
            302668, "TW", "Taiwan", "AS",
            WikipediaBase + "Taiwan",
            "Taiwanese airports"
        ),
        new Country(
            302607, "TZ", "Tanzania", "AF",
            WikipediaBase + "Tanzania",
            "Tanzanian airports"
        ),
        new Country(
            302719, "UA", "Ukraine", "EU",
            WikipediaBase + "Ukraine",
            "Аеропорти України"
        ),
        new Country(
            302608, "UG", "Uganda", "AF",
            WikipediaBase + "Uganda",
            ""
        ),
        new Country(
            302785, "UM", "United States Minor Outlying Islands", "OC",
            WikipediaBase + "United_States_Minor_Outlying_Islands",
            "Airports in United States Minor Outlying Islands"
        ),
        new Country(
            302755, "US", "United States", "NA",
            WikipediaBase + "United_States",
            "American airports"
        ),
        new Country(
            302801, "UY", "Uruguay", "SA",
            WikipediaBase + "Uruguay",
            "Aeropuertos de Uruguay"
        ),
        new Country(
            302669, "UZ", "Uzbekistan", "AS",
            WikipediaBase + "Uzbekistan",
            "Uzbek"
        ),
        new Country(
            302721, "VA", "Vatican City", "EU",
            WikipediaBase + "Vatican_City",
            "The Holy See"
        ),
        new Country(
            302756, "VC", "Saint Vincent and the Grenadines", "NA",
            WikipediaBase + "Saint_Vincent_and_the_Grenadines",
            "Airports in Saint Vincent and the Grenadines"
        ),
        new Country(
            302802, "VE", "Venezuela", "SA",
            WikipediaBase + "Venezuela",
            "Aeropuertos de Venezuela"
        ),
        new Country(
            302757, "VG", "British Virgin Islands", "NA",
            WikipediaBase + "British_Virgin_Islands",
            "Airports in British Virgin Islands"
        ),
        new Country(
            302758, "VI", "U.S. Virgin Islands", "NA",
            WikipediaBase + "U.S._Virgin_Islands",
            "Airports in U.S. Virgin Islands"
        ),
        new Country(
            302670, "VN", "Vietnam", "AS",
            WikipediaBase + "Vietnam",
            "Các sân bay của Việt Nam"
        ),
        new Country(
            302786, "VU", "Vanuatu", "OC",
            WikipediaBase + "Vanuatu",
            "Airports in Vanuatu"
        ),
        new Country(
            302787, "WF", "Wallis and Futuna", "OC",
            WikipediaBase + "Wallis_and_Futuna",
            "Airports in Wallis and Futuna"
        ),
        new Country(
            302788, "WS", "Samoa", "OC",
            WikipediaBase + "Samoa",
            "Samoan airports"
        ),
        new Country(
            302720, "XK", "Kosovo", "EU",
            WikipediaBase + "Kosovo",
            "Kosova"
        ),
        new Country(
            593722, "XP", "Paracel Islands (disputed)", "AS",
            WikipediaBase + "Paracel_Islands",
            "China, Vietnam, Taiwan"
        ),
        new Country(
            302671, "YE", "Yemen", "AS",
            WikipediaBase + "Yemen",
            "مطارات اليمن"
        ),
        new Country(
            302609, "YT", "Mayotte", "AF",
            WikipediaBase + "Mayotte",
            "Airports in Mayotte"
        ),
        new Country(
            302610, "ZA", "South Africa", "AF",
            WikipediaBase + "South_Africa",
            "South African airports"
        ),
        new Country(
            302611, "ZM", "Zambia", "AF",
            WikipediaBase + "Zambia",
            "Zambian airports"
        ),
        new Country(
            302612, "ZW", "Zimbabwe", "AF",
            WikipediaBase + "Zimbabwe",
            "Zimbabwan airports"
        ),
        new Country(
            302613, "ZZ", "Unknown or unassigned country", "AF",
            WikipediaBase + "Unknown_or_unassigned_country",
            "Airports in Unknown or unassigned country"
        ),
    };
}