using UnityEngine;
using System.Collections;
public class Main_Camera_GameDisplayScript_t : MonoBehaviour {
float[] animVar;
float deltaTime;
float startTime;
void Start(){
startTime = Time.time;
deltaTime = 1f/60f;
animVar = new float[560];
animVar[0] = 0.000000f;
animVar[1] = 0.000000f;
animVar[2] = 0.000000f;
animVar[3] = 0.000000f;
animVar[4] = 0.000000f;
animVar[5] = 0.000000f;
animVar[6] = 0.000000f;
animVar[7] = 0.000000f;
animVar[8] = 0.000000f;
animVar[9] = 0.000000f;
animVar[10] = 0.000000f;
animVar[11] = 0.000000f;
animVar[12] = 0.000000f;
animVar[13] = 0.000000f;
animVar[14] = 0.000000f;
animVar[15] = 0.000000f;
animVar[16] = 0.000000f;
animVar[17] = 0.000000f;
animVar[18] = 0.000000f;
animVar[19] = 0.000000f;
animVar[20] = 0.000000f;
animVar[21] = 0.000000f;
animVar[22] = 0.000000f;
animVar[23] = 0.000000f;
animVar[24] = 0.000000f;
animVar[25] = 0.000000f;
animVar[26] = 0.000000f;
animVar[27] = 0.000000f;
animVar[28] = 0.000000f;
animVar[29] = 0.000000f;
animVar[30] = 0.000000f;
animVar[31] = 0.000000f;
animVar[32] = 0.000000f;
animVar[33] = 0.000000f;
animVar[34] = 0.000000f;
animVar[35] = 0.000000f;
animVar[36] = 0.000000f;
animVar[37] = 0.000000f;
animVar[38] = 0.000000f;
animVar[39] = 0.000000f;
animVar[40] = 0.000000f;
animVar[41] = 0.000000f;
animVar[42] = 0.000000f;
animVar[43] = 0.000000f;
animVar[44] = 0.000000f;
animVar[45] = 0.000000f;
animVar[46] = 0.000000f;
animVar[47] = 0.000000f;
animVar[48] = 0.000000f;
animVar[49] = 0.000000f;
animVar[50] = 0.000000f;
animVar[51] = 0.000000f;
animVar[52] = 0.000000f;
animVar[53] = 0.000000f;
animVar[54] = 0.000000f;
animVar[55] = 0.000000f;
animVar[56] = 0.000000f;
animVar[57] = 0.000000f;
animVar[58] = 0.000000f;
animVar[59] = 0.000000f;
animVar[60] = 0.000000f;
animVar[61] = 0.000000f;
animVar[62] = 0.000000f;
animVar[63] = 0.000000f;
animVar[64] = 0.000000f;
animVar[65] = 0.000000f;
animVar[66] = 0.000000f;
animVar[67] = 0.000000f;
animVar[68] = 0.000000f;
animVar[69] = 0.000000f;
animVar[70] = 0.000000f;
animVar[71] = 0.000000f;
animVar[72] = 0.000000f;
animVar[73] = 0.000000f;
animVar[74] = 0.000000f;
animVar[75] = 0.000000f;
animVar[76] = 0.000000f;
animVar[77] = 0.000000f;
animVar[78] = 0.000000f;
animVar[79] = 0.000000f;
animVar[80] = 0.000000f;
animVar[81] = 0.000000f;
animVar[82] = 0.000000f;
animVar[83] = 0.000000f;
animVar[84] = 0.000000f;
animVar[85] = 0.000000f;
animVar[86] = 0.000000f;
animVar[87] = 0.000000f;
animVar[88] = 0.000000f;
animVar[89] = 0.000000f;
animVar[90] = 0.000000f;
animVar[91] = 0.000000f;
animVar[92] = 0.000000f;
animVar[93] = 0.000000f;
animVar[94] = 0.000000f;
animVar[95] = 0.000000f;
animVar[96] = 0.000000f;
animVar[97] = 0.000000f;
animVar[98] = 0.000000f;
animVar[99] = 0.000000f;
animVar[100] = 0.000000f;
animVar[101] = 0.000000f;
animVar[102] = 0.000000f;
animVar[103] = 0.000000f;
animVar[104] = 0.000000f;
animVar[105] = 0.000000f;
animVar[106] = 0.000000f;
animVar[107] = 0.000000f;
animVar[108] = 0.000000f;
animVar[109] = 0.000000f;
animVar[110] = 0.000000f;
animVar[111] = 0.000000f;
animVar[112] = 0.000000f;
animVar[113] = 0.000000f;
animVar[114] = 0.000000f;
animVar[115] = 0.000000f;
animVar[116] = 0.000000f;
animVar[117] = 0.000000f;
animVar[118] = 0.000000f;
animVar[119] = 0.000000f;
animVar[120] = 0.000000f;
animVar[121] = 0.000000f;
animVar[122] = 0.000000f;
animVar[123] = 0.000000f;
animVar[124] = 0.000000f;
animVar[125] = 0.000000f;
animVar[126] = 0.000000f;
animVar[127] = 0.000000f;
animVar[128] = 0.000000f;
animVar[129] = 0.000000f;
animVar[130] = 0.000000f;
animVar[131] = 0.000000f;
animVar[132] = 0.000000f;
animVar[133] = 0.000000f;
animVar[134] = 0.000000f;
animVar[135] = 0.000000f;
animVar[136] = 0.000000f;
animVar[137] = 0.000000f;
animVar[138] = 0.000000f;
animVar[139] = 0.000000f;
animVar[140] = 0.000000f;
animVar[141] = 0.000000f;
animVar[142] = 0.000000f;
animVar[143] = 0.000000f;
animVar[144] = 0.000000f;
animVar[145] = 0.000000f;
animVar[146] = 0.000000f;
animVar[147] = 0.000000f;
animVar[148] = 0.000000f;
animVar[149] = 0.000000f;
animVar[150] = 0.000000f;
animVar[151] = 0.000000f;
animVar[152] = 0.000000f;
animVar[153] = 0.000000f;
animVar[154] = 0.000000f;
animVar[155] = 0.000000f;
animVar[156] = 0.000000f;
animVar[157] = 0.000000f;
animVar[158] = 0.000000f;
animVar[159] = 0.000000f;
animVar[160] = 0.000000f;
animVar[161] = 0.000000f;
animVar[162] = 0.000000f;
animVar[163] = 0.000000f;
animVar[164] = 0.000000f;
animVar[165] = 0.000000f;
animVar[166] = 0.000000f;
animVar[167] = 0.000000f;
animVar[168] = 0.000000f;
animVar[169] = 0.000000f;
animVar[170] = 0.000000f;
animVar[171] = 0.000000f;
animVar[172] = 0.000000f;
animVar[173] = 0.000000f;
animVar[174] = 0.000000f;
animVar[175] = 0.000000f;
animVar[176] = 0.000000f;
animVar[177] = 0.000000f;
animVar[178] = 0.000000f;
animVar[179] = 0.000000f;
animVar[180] = 0.000000f;
animVar[181] = 0.000000f;
animVar[182] = 0.000000f;
animVar[183] = 0.000000f;
animVar[184] = 0.000000f;
animVar[185] = 0.000000f;
animVar[186] = 0.000000f;
animVar[187] = 0.000000f;
animVar[188] = 0.000000f;
animVar[189] = 0.000000f;
animVar[190] = 0.000000f;
animVar[191] = 0.000000f;
animVar[192] = 0.000000f;
animVar[193] = 0.000000f;
animVar[194] = 0.000000f;
animVar[195] = 0.000000f;
animVar[196] = 0.000000f;
animVar[197] = 0.000000f;
animVar[198] = 0.000000f;
animVar[199] = 0.000000f;
animVar[200] = 0.000000f;
animVar[201] = 0.000000f;
animVar[202] = 0.000000f;
animVar[203] = 0.000000f;
animVar[204] = 0.000000f;
animVar[205] = 0.000000f;
animVar[206] = 0.000000f;
animVar[207] = 0.000000f;
animVar[208] = 0.000000f;
animVar[209] = 0.000000f;
animVar[210] = 0.000000f;
animVar[211] = 0.000000f;
animVar[212] = 0.000000f;
animVar[213] = 0.000000f;
animVar[214] = 0.000000f;
animVar[215] = 0.000000f;
animVar[216] = 0.000000f;
animVar[217] = 0.000000f;
animVar[218] = 0.000000f;
animVar[219] = 0.000000f;
animVar[220] = 0.000000f;
animVar[221] = 0.000000f;
animVar[222] = 0.000000f;
animVar[223] = 0.000000f;
animVar[224] = 0.000000f;
animVar[225] = 0.000000f;
animVar[226] = 0.000000f;
animVar[227] = 0.000000f;
animVar[228] = 0.000000f;
animVar[229] = 0.000000f;
animVar[230] = 0.000000f;
animVar[231] = 0.000000f;
animVar[232] = 0.000000f;
animVar[233] = 0.000000f;
animVar[234] = 0.000000f;
animVar[235] = 0.000000f;
animVar[236] = 0.000000f;
animVar[237] = 0.000000f;
animVar[238] = 0.000000f;
animVar[239] = 0.000000f;
animVar[240] = 0.000000f;
animVar[241] = 0.000000f;
animVar[242] = 0.000000f;
animVar[243] = 0.000000f;
animVar[244] = 0.000000f;
animVar[245] = 0.000000f;
animVar[246] = 0.000000f;
animVar[247] = 0.000000f;
animVar[248] = 0.000000f;
animVar[249] = 0.000000f;
animVar[250] = 0.000000f;
animVar[251] = 0.000000f;
animVar[252] = 0.000000f;
animVar[253] = 0.000000f;
animVar[254] = 0.000000f;
animVar[255] = 0.000000f;
animVar[256] = 0.000000f;
animVar[257] = 0.000000f;
animVar[258] = 0.000000f;
animVar[259] = 0.000000f;
animVar[260] = 0.000000f;
animVar[261] = 0.000000f;
animVar[262] = 0.000000f;
animVar[263] = 0.000000f;
animVar[264] = 0.000000f;
animVar[265] = 0.000000f;
animVar[266] = 0.000000f;
animVar[267] = 0.000000f;
animVar[268] = 0.000000f;
animVar[269] = 0.000000f;
animVar[270] = 0.000000f;
animVar[271] = 0.000000f;
animVar[272] = 0.000000f;
animVar[273] = 0.000000f;
animVar[274] = 0.000000f;
animVar[275] = 0.000000f;
animVar[276] = 0.000000f;
animVar[277] = 0.000000f;
animVar[278] = 0.000000f;
animVar[279] = 0.000000f;
animVar[280] = 0.000000f;
animVar[281] = 0.000000f;
animVar[282] = 0.000000f;
animVar[283] = 0.000000f;
animVar[284] = 0.000000f;
animVar[285] = 0.000000f;
animVar[286] = 0.000000f;
animVar[287] = 0.000000f;
animVar[288] = 0.000000f;
animVar[289] = 0.000000f;
animVar[290] = 0.000000f;
animVar[291] = 0.000000f;
animVar[292] = 0.000000f;
animVar[293] = 0.000000f;
animVar[294] = 0.000000f;
animVar[295] = 0.000000f;
animVar[296] = 0.000000f;
animVar[297] = 0.000000f;
animVar[298] = 0.000000f;
animVar[299] = 0.000000f;
animVar[300] = 0.000000f;
animVar[301] = 0.000000f;
animVar[302] = 0.000000f;
animVar[303] = 0.000000f;
animVar[304] = 0.000000f;
animVar[305] = 0.000000f;
animVar[306] = 0.000000f;
animVar[307] = 0.000000f;
animVar[308] = 0.000000f;
animVar[309] = 0.000000f;
animVar[310] = 0.000000f;
animVar[311] = 0.000000f;
animVar[312] = 0.000000f;
animVar[313] = 0.000000f;
animVar[314] = 0.000000f;
animVar[315] = 0.000000f;
animVar[316] = 0.000000f;
animVar[317] = 0.000000f;
animVar[318] = 0.000000f;
animVar[319] = 0.000000f;
animVar[320] = 0.000000f;
animVar[321] = 0.000000f;
animVar[322] = 0.000000f;
animVar[323] = 0.000000f;
animVar[324] = 0.000000f;
animVar[325] = 0.000000f;
animVar[326] = 0.000000f;
animVar[327] = 0.000000f;
animVar[328] = 0.000000f;
animVar[329] = 0.000000f;
animVar[330] = 0.000000f;
animVar[331] = 0.000000f;
animVar[332] = 0.000000f;
animVar[333] = 0.000000f;
animVar[334] = 0.000000f;
animVar[335] = 0.000000f;
animVar[336] = 0.000000f;
animVar[337] = 0.000000f;
animVar[338] = 0.000000f;
animVar[339] = 0.000000f;
animVar[340] = 0.000000f;
animVar[341] = 0.000000f;
animVar[342] = 0.000000f;
animVar[343] = 0.000000f;
animVar[344] = 0.000000f;
animVar[345] = 0.000000f;
animVar[346] = 0.000000f;
animVar[347] = 0.000000f;
animVar[348] = 0.000000f;
animVar[349] = 0.000000f;
animVar[350] = 0.000000f;
animVar[351] = 0.000000f;
animVar[352] = 0.000228f;
animVar[353] = 0.012067f;
animVar[354] = 0.040338f;
animVar[355] = 0.082925f;
animVar[356] = 0.137706f;
animVar[357] = 0.202567f;
animVar[358] = 0.275384f;
animVar[359] = 0.354046f;
animVar[360] = 0.436427f;
animVar[361] = 0.520416f;
animVar[362] = 0.603891f;
animVar[363] = 0.684730f;
animVar[364] = 0.760821f;
animVar[365] = 0.830040f;
animVar[366] = 0.890274f;
animVar[367] = 0.939400f;
animVar[368] = 0.975303f;
animVar[369] = 0.995863f;
animVar[370] = 1.000000f;
animVar[371] = 1.000000f;
animVar[372] = 1.000000f;
animVar[373] = 1.000000f;
animVar[374] = 1.000000f;
animVar[375] = 1.000000f;
animVar[376] = 1.000000f;
animVar[377] = 1.000000f;
animVar[378] = 1.000000f;
animVar[379] = 1.000000f;
animVar[380] = 1.000000f;
animVar[381] = 1.000000f;
animVar[382] = 1.000000f;
animVar[383] = 1.000000f;
animVar[384] = 1.000000f;
animVar[385] = 1.000000f;
animVar[386] = 1.000000f;
animVar[387] = 1.000000f;
animVar[388] = 1.000000f;
animVar[389] = 1.000000f;
animVar[390] = 1.000000f;
animVar[391] = 1.000000f;
animVar[392] = 1.000000f;
animVar[393] = 1.000000f;
animVar[394] = 1.000000f;
animVar[395] = 1.000000f;
animVar[396] = 1.000000f;
animVar[397] = 1.000000f;
animVar[398] = 1.000000f;
animVar[399] = 1.000000f;
animVar[400] = 1.000000f;
animVar[401] = 1.000000f;
animVar[402] = 1.000000f;
animVar[403] = 1.000000f;
animVar[404] = 1.000000f;
animVar[405] = 1.000000f;
animVar[406] = 1.000000f;
animVar[407] = 1.000000f;
animVar[408] = 1.000000f;
animVar[409] = 1.000000f;
animVar[410] = 1.000000f;
animVar[411] = 1.000000f;
animVar[412] = 1.000000f;
animVar[413] = 1.000000f;
animVar[414] = 1.000000f;
animVar[415] = 1.000000f;
animVar[416] = 1.000000f;
animVar[417] = 1.000000f;
animVar[418] = 1.000000f;
animVar[419] = 1.000000f;
animVar[420] = 1.000000f;
animVar[421] = 1.000000f;
animVar[422] = 1.000000f;
animVar[423] = 1.000000f;
animVar[424] = 1.000000f;
animVar[425] = 1.000000f;
animVar[426] = 1.000000f;
animVar[427] = 1.000000f;
animVar[428] = 1.000000f;
animVar[429] = 1.000000f;
animVar[430] = 1.000000f;
animVar[431] = 1.000000f;
animVar[432] = 1.000000f;
animVar[433] = 1.000000f;
animVar[434] = 1.000000f;
animVar[435] = 1.000000f;
animVar[436] = 1.000000f;
animVar[437] = 1.000000f;
animVar[438] = 1.000000f;
animVar[439] = 1.000000f;
animVar[440] = 1.000000f;
animVar[441] = 1.000000f;
animVar[442] = 1.000000f;
animVar[443] = 1.000000f;
animVar[444] = 1.000000f;
animVar[445] = 1.000000f;
animVar[446] = 1.000000f;
animVar[447] = 1.000000f;
animVar[448] = 1.000000f;
animVar[449] = 1.000000f;
animVar[450] = 1.000000f;
animVar[451] = 1.000000f;
animVar[452] = 1.000000f;
animVar[453] = 1.000000f;
animVar[454] = 1.000000f;
animVar[455] = 1.000000f;
animVar[456] = 1.000000f;
animVar[457] = 1.000000f;
animVar[458] = 1.000000f;
animVar[459] = 1.000000f;
animVar[460] = 1.000000f;
animVar[461] = 1.000000f;
animVar[462] = 1.000000f;
animVar[463] = 1.000000f;
animVar[464] = 1.000000f;
animVar[465] = 1.000000f;
animVar[466] = 1.000000f;
animVar[467] = 1.000000f;
animVar[468] = 1.000000f;
animVar[469] = 1.000000f;
animVar[470] = 1.000000f;
animVar[471] = 1.000000f;
animVar[472] = 1.000000f;
animVar[473] = 1.000000f;
animVar[474] = 1.000000f;
animVar[475] = 1.000000f;
animVar[476] = 1.000000f;
animVar[477] = 1.000000f;
animVar[478] = 1.000000f;
animVar[479] = 1.000000f;
animVar[480] = 1.000000f;
animVar[481] = 1.000000f;
animVar[482] = 1.000000f;
animVar[483] = 1.000000f;
animVar[484] = 1.000000f;
animVar[485] = 1.000000f;
animVar[486] = 1.000000f;
animVar[487] = 1.000000f;
animVar[488] = 1.000000f;
animVar[489] = 1.000000f;
animVar[490] = 1.000000f;
animVar[491] = 1.000000f;
animVar[492] = 1.000000f;
animVar[493] = 1.000000f;
animVar[494] = 1.000000f;
animVar[495] = 1.000000f;
animVar[496] = 1.000000f;
animVar[497] = 1.000000f;
animVar[498] = 1.000000f;
animVar[499] = 1.000000f;
animVar[500] = 1.000000f;
animVar[501] = 1.000000f;
animVar[502] = 1.000000f;
animVar[503] = 1.000000f;
animVar[504] = 1.000000f;
animVar[505] = 1.000000f;
animVar[506] = 1.000000f;
animVar[507] = 1.000000f;
animVar[508] = 1.000000f;
animVar[509] = 1.000000f;
animVar[510] = 1.000000f;
animVar[511] = 1.000000f;
animVar[512] = 1.000000f;
animVar[513] = 1.000000f;
animVar[514] = 1.000000f;
animVar[515] = 1.000000f;
animVar[516] = 1.000000f;
animVar[517] = 1.000000f;
animVar[518] = 1.000000f;
animVar[519] = 1.000000f;
animVar[520] = 1.000000f;
animVar[521] = 1.000000f;
animVar[522] = 1.000000f;
animVar[523] = 1.000000f;
animVar[524] = 1.000000f;
animVar[525] = 1.000000f;
animVar[526] = 1.000000f;
animVar[527] = 1.000000f;
animVar[528] = 1.000000f;
animVar[529] = 1.000000f;
animVar[530] = 1.000000f;
animVar[531] = 1.000000f;
animVar[532] = 1.000000f;
animVar[533] = 1.000000f;
animVar[534] = 1.000000f;
animVar[535] = 1.000000f;
animVar[536] = 1.000000f;
animVar[537] = 1.000000f;
animVar[538] = 1.000000f;
animVar[539] = 1.000000f;
animVar[540] = 1.000000f;
animVar[541] = 1.000000f;
animVar[542] = 1.000000f;
animVar[543] = 1.000000f;
animVar[544] = 1.000000f;
animVar[545] = 1.000000f;
animVar[546] = 1.000000f;
animVar[547] = 1.000000f;
animVar[548] = 1.000000f;
animVar[549] = 1.000000f;
animVar[550] = 1.000000f;
animVar[551] = 1.000000f;
animVar[552] = 1.000000f;
animVar[553] = 1.000000f;
animVar[554] = 1.000000f;
animVar[555] = 1.000000f;
animVar[556] = 1.000000f;
animVar[557] = 1.000000f;
animVar[558] = 1.000000f;
animVar[559] = 1.000000f;
comp = gameObject.GetComponent<GameDisplayScript>();
}
GameDisplayScript comp;
public float numFrame;
void Update () {
numFrame = (Time.time-startTime)/deltaTime;
if( numFrame>=(float)animVar.Length-1 ) {numFrame=(float)animVar.Length-1.01f;}
float alpha = numFrame-Mathf.Floor(numFrame)/deltaTime;
comp.t = Mathf.Lerp(animVar[Mathf.FloorToInt(numFrame)],animVar[Mathf.CeilToInt(numFrame)],alpha);
}
}
